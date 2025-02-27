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
    public partial class TestViewModel(IServiceProvider serviceProvider,IUserService userService,ITestService usersService): ObservableObject
    {
		[ObservableProperty]
		public partial string Title { get; set; } = "Tests";

		[ObservableProperty]
		public partial Person SelectPerson { get; set; } = new();

		[ObservableProperty]
		public partial ObservableCollection<Person> People { get; set; }

		[RelayCommand]
		private void GoToActivities()
		{
			SelectPerson = userService.GetPerson();
			People = usersService.GetPeople();

			var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = serviceProvider.GetRequiredService<ActivitiesViewModel>();
		}
	}
}
