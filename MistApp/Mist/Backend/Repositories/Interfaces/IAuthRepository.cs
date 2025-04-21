using Mist.Backend.DTOs;
using Mist.Backend.Entities;

namespace Mist.Backend.Repositories.Interfaces;

public interface IAuthRepository
{
	Task<User> LoginUserAsync(LoginUserDto dto);
}
