using Microsoft.EntityFrameworkCore;
using Mist.Backend.Data;
using Mist.Backend.DTOs;
using Mist.Backend.Entities;
using Mist.Backend.Repositories.Interfaces;

namespace Mist.Backend.Repositories.Implementations;

public class AuthRepository : IAuthRepository
{
	private readonly MistDbContext _dbContext;

	public AuthRepository(MistDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<User> LoginUserAsync(LoginUserDto dto)
	{
		var retrievedUser = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);

		if (retrievedUser != null)
		{
			return retrievedUser; 
		}
		throw new KeyNotFoundException($"User email - {dto.Email} not found.");
	}
}