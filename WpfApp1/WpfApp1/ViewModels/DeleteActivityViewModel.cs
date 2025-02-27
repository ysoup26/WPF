using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
	public partial class DeleteActivityViewModel: ObservableObject
	{
		private readonly IServiceProvider _serviceProvider;

		public DeleteActivityViewModel(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;

		}
		[RelayCommand]
		private void GoToActivities()
		{
			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ActivitiesViewModel>();
		}
	}
}
