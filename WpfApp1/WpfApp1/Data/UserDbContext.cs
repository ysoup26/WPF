using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;

namespace WpfApp1.Data
{
	public partial class UserDbContext: DbContext
	{
		public DbSet<User> Users { get; set; }

		public UserDbContext(DbContextOptions<UserDbContext> options) 
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData
				(
				new User { Id=1,Irum="홍길동",Age= 30},
				new User { Id=2,Irum="이순신",Age= 45}
				);
		}
	}
}
