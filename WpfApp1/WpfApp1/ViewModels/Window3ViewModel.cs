using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using WpfApp1.Controls;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public partial class Window3ViewModel: ObservableObject
    {
		public ICollectionView PeopleView { get; }

		[ObservableProperty]
		public partial Person SelectedPerson { get; set; }

		[ObservableProperty]
		public partial ObservableCollection<Person> People { get; set; }


		[ObservableProperty]
		public partial ObservableObject CurrentViewModel { get; set; } //declare

		[ObservableProperty]
		public partial object CurrentView { get; set; } //declare

		[ObservableProperty]
		public partial DataGridCtrl DataGridCtrlView { get; set; } //declare		
															   
		[ObservableProperty]
		public partial ListViewCtrl ListCtrlView { get; set; } //declare

		public Window3ViewModel()
		{
			ShowViewA();

			DataGridCtrlView = new DataGridCtrl();
			ListCtrlView = new ListViewCtrl();
			
			People = new()
			{
				new Person{Id=1, Age=11, Address="seoul",Gender=true,Irum="leebok1",Telephone="1234-5678"},
				new Person{Id=2, Age=22, Address="busan",Gender=false,Irum="leebok2",Telephone="2344-5678"},
				new Person{Id=3, Age=33, Address="daegu",Gender=true,Irum="leebok3",Telephone="3444-5678"},
				new Person{Id=4, Age=44, Address="kwangju",Gender=true,Irum="leebok4",Telephone="5644-5678"},
				new Person{Id=5, Age=55, Address="inchun",Gender=true,Irum="leebok5",Telephone="5234-5678"},
				new Person{Id=6, Age=66, Address="jaeju",Gender=true,Irum="leebok6",Telephone="5644-5678"},
			};

			PeopleView = CollectionViewSource.GetDefaultView(People); //포인터 작업
			PeopleView.SortDescriptions.Add(new SortDescription(nameof(Person.Id), ListSortDirection.Descending));

			//PeopleView.Filter = item => item is Person person && person.Age > 30;

			PeopleView.Refresh();

			var newPerson = new Person
			{
				Id = People.Count + 1,
				Irum = $"New Person {People.Count + 1}",
				Age = new Random().Next(20, 50),
				Address = "Seoul",
				Telephone = "1234-1234",
				Gender = true,
			};
			People.Add(newPerson);
			PeopleView.Refresh();

			SelectedPerson = newPerson;

			DataGridCtrlView.DataContext = PeopleView;
			ListCtrlView.DataContext = PeopleView;
		}

		[RelayCommand] //button click command service
		private void SelectionChanged(Person selectedItem) 
		{
			Debug.WriteLine("SelectionChanged");

			//Person? per = PeopleView.CurrentItem as Person;
			//SelectedPerson = per;
			//SelectedPerson = selectedItem;

			//직접 이동으로 포인트 이동
			//PeopleView.MoveCurrentToPrevious();
			//Person per = PeopleView.CurrentItem as Person;
			//SelectedPerson = per;

			if (selectedItem != null)
			{
				SelectedPerson = selectedItem;
				//System.Diagnostics.Debug.WriteLine($"Selected Item: {selectedItem.Irum}");
			}
		}

		[RelayCommand]
		private void SeleMoveNextChanged(Person selectedItem)
		{
			Debug.WriteLine("SeleChanged");

			//if (selectedItem != null)
			//{
				PeopleView.MoveCurrentToNext();
				//Person? per = PeopleView.CurrentItem as Person;
				SelectedPerson = PeopleView.CurrentItem as Person; 
				//System.Diagnostics.Debug.WriteLine($"Selected Item: {selectedItem.Irum}");
			//}
		}
		[RelayCommand]
		private void SeleMovePrevChanged(Person selectedItem)
		{
			Debug.WriteLine("SeleChanged");

			PeopleView.MoveCurrentToLast();
			//if (selectedItem != null)
			//{
			PeopleView.MoveCurrentToPrevious();
				//Person? per = PeopleView.CurrentItem as Person;
				SelectedPerson = PeopleView.CurrentItem as Person;
				//System.Diagnostics.Debug.WriteLine($"Selected Item: {selectedItem.Irum}");
			//}
		}
		[RelayCommand]
		private void SeleCurrentChanged(Person selectedItem)
		{
			//Person? per = PeopleView.CurrentItem as Person;
			//SelectedPerson = per;
			//}
			SelectedPerson = PeopleView.CurrentItem as Person;


		}

		[RelayCommand]
		private void SeleChanged(Person selectedItem)
		{
			Debug.WriteLine("SeleChanged");
			if (selectedItem != null)
			{
				SelectedPerson = selectedItem;
				//System.Diagnostics.Debug.WriteLine($"Selected Item: {selectedItem.Irum}");
			}
		}
		[RelayCommand]
		private void AddPerson()
		{
			Debug.WriteLine("AddPerson");
			var newPerson = new Person
			{
				Id = People.Count + 1,
				Irum = $"New Person {People.Count + 1}",
				Age = new Random().Next(20, 50),
				Address = "Seoul",
				Telephone = "1234-1234",
				Gender = true,
			};
			People.Add(newPerson);
			PeopleView.Refresh();
		}

		[RelayCommand]
		private void RemovePerson()
		{
			Debug.WriteLine("RemovePerson");
			if (SelectedPerson != null)
			{
				People.Remove(SelectedPerson);
				SelectedPerson = null;
				PeopleView.Refresh();

			}
		}

		[RelayCommand]
		private void UpdatePerson()
		{
			Debug.WriteLine("UpdatePerson");
			if (SelectedPerson != null)
			{
				SelectedPerson.Irum += "(Updated)";
				PeopleView.Refresh();
			}
		}

		[RelayCommand]
		private void ShowViewA()
		{
			CurrentView = new ViewA();
		}

		[RelayCommand]
		private void ShowViewB()
		{
			CurrentView = new ViewB();
		}
	}
}
