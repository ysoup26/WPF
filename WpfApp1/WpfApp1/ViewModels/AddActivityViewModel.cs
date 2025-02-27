using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public partial class AddActivityViewModel : ObservableObject
	{
		[ObservableProperty]
		public partial string Title { get; set; } = "Add New Activity";

		
		[ObservableProperty]
		public partial Person? SelectedPerson { get; set; }

		private readonly IServiceProvider _serviceProvider;

		public AddActivityViewModel(IServiceProvider serviceProvider, IUserService userService)
		{
			_serviceProvider = serviceProvider;
			SelectedPerson = userService.GetPerson();
		}


		[RelayCommand]
		private void GoToActivities()
		{
			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ActivitiesViewModel>();
		}

		[RelayCommand]
		private void GoToTestViewActivity()
		{
			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<TestViewModel>();
		}
	}
}
