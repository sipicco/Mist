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

	public async Task<GetUserDto?> GetSingleUserAsync(Guid id)
	{
		var retrievedUser = await _dbContext.Users
			.FirstOrDefaultAsync(u => u.Id == id);
			
		if (retrievedUser != null)
		{
			return new GetUserDto
			{
				Username = retrievedUser.Username,
				Email = retrievedUser.Email,
				Id = retrievedUser.Id
			};
		}
		return null;
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

	public async Task<GetUserDto> EditUserAsync(Guid userId, EditUserDto dto)
	{
		var retrievedUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

		if(retrievedUser != null)
		{
			if (retrievedUser.Email != dto.Email || retrievedUser.Username != dto.Username)
			{
				retrievedUser.Email = (!string.IsNullOrWhiteSpace(dto.Email) && dto.Email != "string")
				? dto.Email
				: retrievedUser.Email;

				retrievedUser.Username = (!string.IsNullOrWhiteSpace(dto.Username) && dto.Username != "string")
					? dto.Username
					: retrievedUser.Username;

				await _dbContext.SaveChangesAsync();
			}

			return new GetUserDto
			{
				Id = retrievedUser.Id,
				Email = retrievedUser.Email,
				Username = retrievedUser.Username
			};
		}
		throw new KeyNotFoundException($"User with Id: {userId} could not be found!");		
	}

	public async Task<bool> DeleteUserAsync(Guid userId)
	{
		var userToDelete = await _dbContext.Users.FirstAsync(u => u.Id == userId);

		_dbContext.Remove(userToDelete);
		await _dbContext.SaveChangesAsync();

		return true;
	}

	#region Validation methods

	public async Task<bool> IsEmailExisting(string email)
	{
		return await _dbContext.Users.AnyAsync(u =>  u.Email == email);
	}
	public async Task<bool> IsUsernameExisting(string username)
	{
		return await _dbContext.Users.AnyAsync(u => u.Username == username);
	}

	#endregion
}
