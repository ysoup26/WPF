using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Animation;
using WpfApp1.Models;

namespace WpfApp1.ViewModels   //c# 12.0...primary-constructors...(injector+injection) constructor service
{
    public partial class ActivitiesViewModel: ObservableObject
    {
		//기존 생성자 방식에서 다음과 같이 수정함
		//private readonly IServiceProvider _serviceProvider;
		//injection service....injector service initialization service
		//injection은 딱 한번만
		//ActivitesViewModel(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

		//injector service
		private readonly IServiceProvider _serviceProvider;

		// injection service 
		public ActivitiesViewModel(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;

			PeopleView = CollectionViewSource.GetDefaultView(People); //포인터 작업
			//PeopleView.SortDescriptions.Add(new SortDescription(nameof(Person.Id), ListSortDirection.Descending));

			//PeopleView.Filter = item => item is Person person && person.Age > 0;

			SelectedPerson = new Person
			{
				Id = People[0].Id,
				Irum = People[0].Irum,
				Age = People[0].Age,
				Address = People[0].Address,
				Telephone = People[0].Telephone,
				Gender = People[0].Gender,
			};
		}

		public ICollectionView PeopleView { get; }

		[ObservableProperty]
		public partial Person? SelectedPerson { get; set; }

		[ObservableProperty]
		public partial ObservableCollection<Person> People { get; set; } //= [.. LinearQuaternionKeyFrame QuerySet];
			= [
				new Person{Id=1, Age=11, Address="seoul",Gender=true,Irum="leebok1",Telephone="1234-5678"},
				new Person{Id=2, Age=22, Address="busan",Gender=false,Irum="leebok2",Telephone="2344-5678"},
				new Person{Id=3, Age=33, Address="daegu",Gender=true,Irum="leebok3",Telephone="3444-5678"},
				new Person{Id=4, Age=44, Address="kwangju",Gender=true,Irum="leebok4",Telephone="5644-5678"},
				new Person{Id=5, Age=55, Address="inchun",Gender=true,Irum="leebok5",Telephone="5234-5678"},
				new Person{Id=6, Age=66, Address="jaeju",Gender=true,Irum="leebok6",Telephone="5644-5678"},
			];

		[ObservableProperty]
		public partial string Title { get; set; } = "People List Activity"; //

		[RelayCommand]
		private void GoToAddActivity()
		{
			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>(); 
			mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddActivityViewModel>();
		}
		[RelayCommand]
		private void GoToTestActivity()
		{
			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<TestViewModel>();
		}

		[RelayCommand]
		private void GoToSelectPersonActivity()
		{
			var selePersonViewModel = _serviceProvider.GetRequiredService<SelectActivityViewModel>();
			
			selePersonViewModel.SelectedPerson = SelectedPerson;

			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = selePersonViewModel;
		}

		[RelayCommand]
		private void GoToInsertPersonActivity()
		{
			var insertPersonViewModel = _serviceProvider.GetRequiredService<AddActivityViewModel>();

			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = insertPersonViewModel;
		}
		[RelayCommand]
		private void GoToDeletePersonActivity()
		{
			var deletePersonViewModel = _serviceProvider.GetRequiredService<DeleteActivityViewModel>();

			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = deletePersonViewModel;
		}
		[RelayCommand]
		private void GoToUpdatePersonActivity()
		{
			var updatePersonViewModel = _serviceProvider.GetRequiredService<UpdateActivityViewModel>();

			var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
			mainViewModel.CurrentViewModel = updatePersonViewModel;
		}

		[RelayCommand] 
		private void SelectionChanged(Person selectedItem)
		{
			if (selectedItem != null)
			{
				//SelectedPerson = PeopleView.CurrentItem as Person;
				SelectedPerson = selectedItem;
			}
		}
	}
}
