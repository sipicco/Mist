using Mist.Backend.DTOs;
using Mist.Backend.Models;

namespace Mist.Backend.Services.Interfaces;

public interface IUserService
{
	Task<GetUserDto> EditUser(Guid userId, EditUserDto dto);
	Task<GetUsersResponse> GetAllUsersAsync();
	Task<GetUsersResponse> GetSingleUserAsync(Guid id);

	/// <summary>
	/// Register a new user in the db
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	Task<Guid> RegisterUserAsync(CreateUserRequest request);
}