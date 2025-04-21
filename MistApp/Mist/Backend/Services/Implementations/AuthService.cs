using Mist.Backend.DTOs;
using Mist.Backend.Models;
using Mist.Backend.Repositories.Interfaces;
using Mist.Backend.Services.Interfaces;

namespace Mist.Backend.Services.Implementations;

public class AuthService : IAuthService
{		
	private readonly IAuthRepository _authRepository;

	public AuthService(IAuthRepository authRepository)
	{
		_authRepository = authRepository;
	}

	public async Task<bool> LoginUserAsync(LoginUserRequest request)
	{
		LoginUserDto dto = new()
		{
			Email = request.Email,
			Password = request.Password
		};

		var retrievedUser = await _authRepository.LoginUserAsync(dto);

		return VerifyPasswordHash(dto.Password, retrievedUser.PasswordHash, retrievedUser.PasswordSalt);
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
