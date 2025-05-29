using Microsoft.EntityFrameworkCore;
using Mist.Backend.Entities;

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

			modelBuilder.Entity<User>()
				.ToTable("users")
				.Property(u => u.Role)
					.HasConversion<string>();

			foreach (var entity in modelBuilder.Model.GetEntityTypes()) // Force tables and columns in lowercase
			{
				entity.SetTableName(entity.GetTableName()!.ToLower());

				foreach (var property in entity.GetProperties())
				{
					property.SetColumnName(property.Name.ToLower());
				}
			}
		}
	}
}
