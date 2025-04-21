using Mist.Backend.DTOs;
using Mist.Backend.Models;
using Mist.Backend.Repositories.Interfaces;
using Mist.Backend.Services.Interfaces;

namespace Mist.Backend.Services.Implementations;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
	{
		return await _userRepository.GetAllUsersAsync();
	}

	public async Task<Guid> RegisterUserAsync(CreateUserRequest request)
	{
		CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);

		var dto = new CreateUserDto
		{
			Username = request.Username,
			Email = request.Email,
			PasswordHash = hash,
			PasswordSalt = salt
		};

		Guid generatedUserId = await _userRepository.CreateUser(dto);
		return generatedUserId;
	}

	private static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
	{
		using var hmac = new System.Security.Cryptography.HMACSHA512();
		salt = hmac.Key;
		hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
	}
}
