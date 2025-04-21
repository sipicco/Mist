using Mist.Backend.DTOs;
using Mist.Backend.Models;

namespace Mist.Backend.Services.Interfaces;

public interface IUserService
{
	Task<IEnumerable<GetUserDto>> GetAllUsersAsync();

	/// <summary>
	/// Register a new user in the db
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	Task<Guid> RegisterUserAsync(CreateUserRequest request);
}