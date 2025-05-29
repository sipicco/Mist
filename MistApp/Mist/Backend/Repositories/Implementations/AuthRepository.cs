using Microsoft.EntityFrameworkCore;
using Mist.Backend.Data;
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

	public async Task<User?> LoginUserAsync(string email)
	{
		return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);		
	}
}