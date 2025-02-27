using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfApp1.Controls;
using WpfApp1.ViewModels;
using WpfApp1.Views;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host; //그릇같은 개념

		public App()
		{
            //가상머신을 만드는 과정 = static container
			_host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    //service registration...resolve GetRequireService()

                    //global
                    services.AddSingleton<MainViewModel>(); 
                    services.AddSingleton<Views.MainWindow>(); 

                    //임시 사용
                    services.AddTransient<ActivitiesViewModel>(); 
                    services.AddTransient<ActivitiesView>(); 
                    services.AddTransient<AddActivityViewModel>(); 
                    services.AddTransient<AddActivityView>();
					services.AddTransient<TestViewModel>();
					services.AddTransient<TestView>();
				})
                .Build();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			//instance(Factory pattern...dynamic)...new instance(static)
			var mainWindow = _host.Services.GetRequiredService<Views.MainWindow>();
			mainWindow.Show();
		}
	}

}
