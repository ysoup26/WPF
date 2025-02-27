using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1.Services
{
	public interface IDbUserService
	{
		Task<List<User>>GetUsersAsync();
		Task AddUserAsync();
		Task UpdateUserAsync(User user);
		Task DeleteUserAsync(User user);
	}

	//top-level parameter service
	public partial class DbUserService(UserDbContext dbContext) : IDbUserService
	{
		////injector
		//private readonly UserDbContext _dbContext;

		////injection
		//public DbUserService(UserDbContext dbContext)
		//{
		//	_dbContext = dbContext;
		//}

		public async Task AddUserAsync()
		{
			var newUser = new User
			{
				Irum = "John",
				Age = 20
			};

			dbContext.Users.Add(newUser);

			await dbContext.SaveChangesAsync();
		}

		public async Task DeleteUserAsync(User user)
		{
			if (user is not null) //pattern operation
			{
				dbContext.Users.Remove(user);
				await dbContext.SaveChangesAsync();
			}
		}
		public async Task<List<User>> GetUsersAsync()
			=> await dbContext.Users.ToListAsync<User>();
		//{
		//	return await dbContext.Users.ToListAsync<User>();	
		//}
		public async Task UpdateUserAsync(User user)
		{
			//if(user != null) -> 레거시 코드, 스토어가 들어가버림
			if (user is not null) //pattern operation
			{
				dbContext.Users.Update(user);
				await dbContext.SaveChangesAsync();
			}
		}
	}
}
