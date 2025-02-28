using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using System.Windows.Media;
using WpfApp1.Controls;
using WpfApp1.Data;
using WpfApp1.Models;
using WpfApp1.Services;
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

					//상단에 두어야함 = store+storage service  ==> db service
					services.AddDbContext<UserDbContext>(options =>
                    options.UseSqlite("Data Source = users.db"));

					//EF Core: SQL provider등록
					services.AddDbContext<SaramDB2Context>(options =>
							options.UseSqlite("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=Saram2DB;Integrated Security=True"));

					//global
					services.AddSingleton<ISaramDbUserService,SaramDbUserService>(); 
                    services.AddSingleton<IDbUserService,DbUserService>(); 
                    services.AddSingleton<IUserService,UserService>(); 
                    services.AddSingleton<ITestService,UsersService>(); 

                    services.AddSingleton<MainViewModel>(); 
                    services.AddSingleton<Views.MainWindow>(); 

                    //임시 사용
                    services.AddTransient<ActivitiesViewModel>(); 
                    services.AddTransient<ActivitiesView>(); 

                    services.AddTransient<AddActivityViewModel>(); 
                    services.AddTransient<AddActivityView>();

					services.AddTransient<TestViewModel>();
					services.AddTransient<TestView>();

					services.AddTransient<DeleteActivityViewModel>();
					services.AddTransient<DeleteActivityView>();

					services.AddTransient<SelectActivityViewModel>();
					services.AddTransient<SelectActivityView>();

					services.AddTransient<UpdateActivityViewModel>();
					services.AddTransient<UpdateActivityView>();
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
