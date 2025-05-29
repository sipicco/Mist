using Microsoft.Extensions.Options;
using Mist.Backend.DTOs;
using Mist.Backend.Entities;
using Mist.Backend.Models;
using Mist.Backend.Repositories.Interfaces;
using Mist.Backend.Services.Interfaces;

namespace Mist.Backend.Services.Implementations;

public class AuthService : IAuthService
{		
	private readonly ITokenService _tokenService;
	private readonly IAuthRepository _authRepository;

	private readonly JwtSettings _jwtSettings;


	public AuthService(ITokenService tokenService, IAuthRepository authRepository, IOptions<JwtSettings> jwtOptions)
	{
		_tokenService = tokenService;
		_authRepository = authRepository;
		_jwtSettings = jwtOptions.Value;
	}

	public async Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request)
	{
		LoginUserDto dto = new()
		{
			Email = request.Email,
			Password = request.Password
		};
		var retrievedUser = await _authRepository.LoginUserAsync(dto.Email);

		if (retrievedUser == null)
		{
			throw new KeyNotFoundException($"User email - {dto.Email} not found.");
		}

		if (!VerifyPasswordHash(dto.Password, retrievedUser.PasswordHash, retrievedUser.PasswordSalt))
		{
			throw new UnauthorizedAccessException($"Wrong passwornd for: {dto.Email}.");
		}

		string accessToken, refreshToken;

		GenerateTokens(retrievedUser, out accessToken, out refreshToken);

		return new LoginUserResponse(
			accessToken,
			refreshToken,
			_jwtSettings.TokenExpiryMinutes * 60
		);
	}

	private void GenerateTokens(User user, out string accessToken, out string refreshToken)
	{
		accessToken = _tokenService.GenerateAccessToken(user);
		refreshToken = _tokenService.GenerateRefreshToken();
	}

	/// <summary>
	/// Hashes the provided password with the stored salt and compares it with the stored hash.
	/// </summary>
	/// <param name="password">The plain-text password to verify.</param>
	/// <param name="hash">The stored password hash to compare against.</param>
	/// <param name="salt">The salt (key) originally used to create the stored hash.</param>
	/// <returns>True if the password matches, otherwise, false.</returns>

	private static bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
	{
		using var hmac = new System.Security.Cryptography.HMACSHA512(salt);
		var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
		return computedHash.SequenceEqual(hash);
	}
}
