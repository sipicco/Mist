using Mist.Backend.Models;

namespace Mist.Backend.Services.Interfaces;

public interface IAuthService
{
	/// <summary>
	/// Retrieves a User from db and verifies password
	/// </summary>
	/// <param name="request"></param>
	/// <returns>True if password is correct</returns>
	Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request);
}
