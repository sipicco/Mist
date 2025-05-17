using Mist.Backend.DTOs;
using Mist.Backend.Models;
using Mist.Backend.Repositories.Interfaces;
using Mist.Backend.Services.Helpers;
using Mist.Backend.Services.Interfaces;

namespace Mist.Backend.Services.Implementations;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<GetUsersResponse> GetAllUsersAsync()
	{
		var dtos = await _userRepository.GetAllUsersAsync();

		return new GetUsersResponse(dtos);
	}

	public async Task<GetUsersResponse> GetSingleUserAsync(Guid id)
	{
		await ValidationHelper.CheckIfUserExistsElseThrow(id, _userRepository);

		var retrievedUser = await _userRepository.GetSingleUserAsync(id);

		var response = new GetUsersResponse(new List<GetUserDto> { retrievedUser });
		return response;
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

	public async Task<GetUserDto> EditUserAsync(Guid userId, EditUserDto dto)
	{
		await ValidationHelper.CheckIfUserExistsElseThrow(userId, _userRepository);

		var updatedUser = await _userRepository.EditUserAsync(userId, dto);
		return updatedUser;
	}

	public async Task<bool> DeleteUserAsync(Guid userId)
	{
		await ValidationHelper.CheckIfUserExistsElseThrow(userId, _userRepository);

		bool userDeleted = await _userRepository.DeleteUserAsync(userId);

		return userDeleted;
	}


	private static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
	{
		using var hmac = new System.Security.Cryptography.HMACSHA512();
		salt = hmac.Key;
		hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
	}
}
