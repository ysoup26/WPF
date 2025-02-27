using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1.ViewModels
{
   public partial class MainViewModel: ObservableObject
    {
		

		[ObservableProperty]
		public partial object CurrentViewModel { get; set; }

		private readonly IServiceProvider _serviceProvider;

		//public MainViewModel()
		//{
		//	//CurrentViewModel = new ActivitiesViewModel();
		//	//var viewModel = serviceProvider.GetRequiredService<ActivitiesViewModel>(); //
		//	//CurrentViewModel = viewModel;
		//}

		public MainViewModel(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			CurrentViewModel = serviceProvider.GetRequiredService<ActivitiesViewModel>();
		}
	}
}
