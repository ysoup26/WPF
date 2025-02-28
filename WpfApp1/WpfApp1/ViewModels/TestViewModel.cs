using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
	//primary constructor
	public partial class TestViewModel(IServiceProvider serviceProvider, IUserService userService, ITestService usersService, IDbUserService dbUserService) : ObservableObject
	{
		[ObservableProperty]
		public partial string Title { get; set; } = "Tests";

		[ObservableProperty]
		public partial Person SelectPerson { get; set; } = new();

		[ObservableProperty]
		public partial User SelectUser { get; set; } = new();

		[ObservableProperty]
		public partial ObservableCollection<Person> People { get; set; }

		[RelayCommand]
		private void GoToActivities()
		{
			SelectPerson = userService.GetPerson();
			People = usersService.GetPeople();

			var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = serviceProvider.GetRequiredService<ActivitiesViewModel>();

			dbUserService.AddUserAsync();

		}

		[RelayCommand]
		private async void GoToDbTestActivity()
		{
			//var users = await dbUserService.GetUsersAsync
			//SelectUser = users.FirstOrDefault();

			await dbUserService.AddUserAsync();

			User user = new User
			{
				Irum = "John",
				Age = 20
			};
			//SelectUser = await dbUserService.AddUserReturnAsync(user).Result; //c# 7.0 value task vs c# 4.0

			//c# 5.0 async /await
			SelectUser = await dbUserService.AddUserReturnAsync(user);
			//People = usersService.Ad;

			var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = serviceProvider.GetRequiredService<ActivitiesViewModel>();

		}
	}
}
