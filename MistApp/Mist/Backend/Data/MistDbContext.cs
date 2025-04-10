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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().HasData(new User
			{
				Id = Guid.Parse("12341234-1234-1234-1234-123412341234"),
				PasswordHash = Convert.FromBase64String("cGFzc3dvcmRoYXNo"), // password hash
				PasswordSalt = Convert.FromBase64String("c2FsdGRhdGE=") // "saltdata"
			});
		}
	}
}
