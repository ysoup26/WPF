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
		Task<User> AddUserReturnAsync(User user);
		Task UpdateUserAsync(User user);
		Task DeleteUserAsync(User user);
	}

	public interface ISaramDbUserService
	{
		Task<List<Saram>> GetUsersAsync();
		Task AddUserAsync();
		Task<Saram> AddUserReturnAsync(Saram user);
		Task UpdateUserAsync(Saram user);
		Task DeleteUserAsync(Saram user);
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

		public async Task<User> AddUserReturnAsync(User imsi)
		{
			//var newUser = new User
			//{
			//	Irum = "John",
			//	Age = 20
			//};
			imsi.Age += 100;

			dbContext.Users.Add(imsi);

			await dbContext.SaveChangesAsync();
			return imsi;
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

	//top-level parameter service
	public partial class SaramDbUserService(SaramDBContext dbContext) 
		: ISaramDbUserService
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
			var newUser = new Saram
			{
				Name = "John",
				Age = 20
			};

			dbContext.Sarams.Add(newUser);

			await dbContext.SaveChangesAsync();
		}

		public async Task<Saram> AddUserReturnAsync(Saram imsi)
		{
			//var newUser = new User
			//{
			//	Irum = "John",
			//	Age = 20
			//};
			imsi.Age += 100;

			dbContext.Sarams.Add(imsi);

			await dbContext.SaveChangesAsync();
			return imsi;
		}

		public async Task DeleteUserAsync(Saram user)
		{
			if (user is not null) //pattern operation
			{
				dbContext.Sarams.Remove(user);
				await dbContext.SaveChangesAsync();
			}
		}
		public async Task<List<Saram>> GetUsersAsync()
			=> await dbContext.Sarams.ToListAsync<Saram>();
		//{
		//	return await dbContext.Users.ToListAsync<User>();	
		//}
		public async Task UpdateUserAsync(Saram user)
		{
			//if(user != null) -> 레거시 코드, 스토어가 들어가버림
			if (user is not null) //pattern operation
			{
				dbContext.Sarams.Update(user);
				await dbContext.SaveChangesAsync();
			}
		}
	}
}
