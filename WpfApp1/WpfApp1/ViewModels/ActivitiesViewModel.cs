using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels   //c# 12.0...primary-constructors...(injector+injection) constructor service
{
    public partial class ActivitiesViewModel(IServiceProvider serviceProvider) : ObservableObject
    {
		//기존 생성자 방식에서 다음과 같이 수정함
		//private readonly IServiceProvider _serviceProvider;
		//injection service....injector service initialization service
		//injection은 딱 한번만
		//ActivitesViewModel(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

		[ObservableProperty]
		public partial string Title { get; set; } = "Activites";

		[RelayCommand]
		private void GoToAddActivity()
		{
			var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>(); 
			mainViewModel.CurrentViewModel = serviceProvider.GetRequiredService<AddActivityViewModel>();
		}
	}
}
