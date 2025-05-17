using Mist.Backend.DTOs;
using Mist.Backend.Models;

namespace Mist.Backend.Services.Interfaces;

public interface IUserService
{
	/// <summary>
	/// Deletes a user from the db
	/// </summary>
	/// <param name="userId"></param>
	/// <returns>True if the user was deleted, else false</returns>
	Task<bool> DeleteUserAsync(Guid userId);
	Task<GetUserDto> EditUserAsync(Guid userId, EditUserDto dto);
	Task<GetUsersResponse> GetAllUsersAsync();
	Task<GetUsersResponse> GetSingleUserAsync(Guid id);

	/// <summary>
	/// Register a new user in the db
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	Task<Guid> RegisterUserAsync(CreateUserRequest request);
}