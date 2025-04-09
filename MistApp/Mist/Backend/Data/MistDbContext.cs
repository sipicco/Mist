using Microsoft.EntityFrameworkCore;
using Mist.Backend.Models;

namespace Mist.Backend.Data
{
	public class MistDbContext : DbContext
	{
		public MistDbContext(DbContextOptions<MistDbContext> options)
			: base(options)
		{
		}

		public DbSet<User> Users {get; set;}
	}
}
