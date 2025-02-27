using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
	public partial class SelectActivityViewModel: ObservableObject
	{
		private readonly IServiceProvider _serviceProvider;

		public SelectActivityViewModel(IServiceProvider serviceProvider,IUserService userService)
		{
			_serviceProvider = serviceProvider;

			SelectedPerson = userService.GetPerson();
		}

		[ObservableProperty]
		public partial Person? SelectedPerson { get; set; }

		[RelayCommand]
		private void GoToActivities()
		{
			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ActivitiesViewModel>();
		}
	}
}
