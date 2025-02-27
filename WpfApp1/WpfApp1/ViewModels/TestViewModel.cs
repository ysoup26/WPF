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
    //primary constructor
    public partial class TestViewModel(IServiceProvider serviceProvider): ObservableObject
    {
		[ObservableProperty]
		public partial string Title { get; set; } = "Activites";

		[RelayCommand]
		private void GoToTestActivity()
		{
			var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = serviceProvider.GetRequiredService<TestViewModel>();
		}
	}
}
