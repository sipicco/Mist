using Mist.Backend.DTOs;

namespace Mist.Backend.Repositories.Interfaces;

public interface IUserRepository
{
	/// <summary>
	/// Adds a new user in the Uers table
	/// </summary>
	/// <param name="dto"></param>
	/// <returns>The Id of the generated user</returns>
	Task<Guid> CreateUser(CreateUserDto dto);
	Task<bool> DeleteUserAsync(Guid userId);
	Task<GetUserDto> EditUserAsync(Guid userId, EditUserDto dto);
	Task<IEnumerable<GetUserDto>> GetAllUsersAsync();
	Task<GetUserDto> GetSingleUserAsync(Guid id);
	Task<bool> IsEmailExisting(string email);
	Task<bool> IsUsernameExisting(string username);
}