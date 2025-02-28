using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
		public partial Person SelectedPerson { get; set; }// = new();

		[ObservableProperty]
		public partial User SelectedUser { get; set; }// = new();

		[ObservableProperty]
		public partial Saram SelectedSaram { get; set; }// = new();


		[ObservableProperty]
		public partial ObservableCollection<Person> People { get; set; }

		[RelayCommand]
		private void GoToActivities()
		{
			//Debug.WriteLine(SelectedPerson.Irum,SelectedPerson.Age);
			//SelectPerson = userService.GetPerson();
			//People = usersService.GetPeople();

			var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = serviceProvider.GetRequiredService<ActivitiesViewModel>();

			//saramDbUserService.AddUserAsync();

		}

		[RelayCommand]
		private async void GoToDbTestActivity()
		{
			//var users = await dbUserService.GetUsersAsync
			//SelectUser = users.FirstOrDefault();

			//await saramDbUserService.AddUserAsync();

			//Saram user = new Saram
			//{
			//	Name = "John",
			//	Age = 20
			//};

			//SelectUser = await dbUserService.AddUserReturnAsync(user).Result; //c# 7.0 value task vs c# 4.0

			//c# 5.0 async /await
			//SelectedSaram = await saramDbUserService.AddUserReturnAsync(user);
			//People = usersService.Ad;

			//var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();
			//mainViewModel.CurrentViewModel = serviceProvider.GetRequiredService<ActivitiesViewModel>();

		}
	}
}
