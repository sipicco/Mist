using Microsoft.EntityFrameworkCore;
using Mist.Backend.Data;
using Mist.Backend.DTOs;
using Mist.Backend.Entities;
using Mist.Backend.Repositories.Interfaces;

namespace Mist.Backend.Repositories.Implementations;

public class UserRepository : IUserRepository
{
	private readonly MistDbContext _dbContext;

	public UserRepository(MistDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
	{
		var retrievedUsers = await _dbContext.Users.ToListAsync();
		return retrievedUsers.Select(u => new GetUserDto
		{
			Username = u.Username,
			Email = u.Email,
			Id = u.Id,
		});
	}

	public async Task<Guid> CreateUser(CreateUserDto dto)
	{
		User user = new User
		{
			Id = Guid.NewGuid(),
			Username = dto.Username,
			Email = dto.Email,
			PasswordHash = dto.PasswordHash,
			PasswordSalt = dto.PasswordSalt
		};

		_dbContext.Add(user);
		await _dbContext.SaveChangesAsync();

		return user.Id;
	}
}
