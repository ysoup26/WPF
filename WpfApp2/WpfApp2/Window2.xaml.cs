using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Collections.ObjectModel;
using WpfApp2.Models;

namespace WpfApp2
{
	/// <summary>
	/// Window2.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class Window2 : Window
	{
		public Window2()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			CollectionViewSource personViewSource = ((CollectionViewSource)(this.FindResource("personViewSource"))); //xaml의 키값을 읽어옴
																									 // CollectionViewSource.Source 속성을 설정하여 데이터를 로드합니다.
																													 // personViewSource.Source = [제네릭 데이터 소스]
			personViewSource.Source = new ObservableCollection<Person>()
			{
				new Person{Id=1, Age=11, Address="seoul",Gender=true,Irum="leebok1",Telephone="1234-5678"},
				new Person{Id=2, Age=22, Address="busan",Gender=false,Irum="leebok2",Telephone="2344-5678"},
				new Person{Id=3, Age=33, Address="daegu",Gender=true,Irum="leebok3",Telephone="3444-5678"},
				new Person{Id=4, Age=44, Address="kwangju",Gender=true,Irum="leebok4",Telephone="5644-5678"},
				new Person{Id=5, Age=55, Address="inchun",Gender=true,Irum="leebok5",Telephone="5234-5678"},
				new Person{Id=6, Age=66, Address="jaeju",Gender=true,Irum="leebok6",Telephone="5644-5678"},
			};

			MessageBox.Show("personViewSource internal operation...");

			var View = personViewSource.View;

			View.Filter = item =>
			{
				Person imsi = item as Person;
				return imsi.Id > 3;
			};

			//View.MoveCurrentToLast();
			//Person imsi = View.CurrentItem as Person;
			//MessageBox.Show(imsi.ToString());

			//View.MoveCurrentToPrevious();
			//imsi = View.CurrentItem as Person;
			//MessageBox.Show(imsi.ToString());

			ICollection<Person> HeleleSet = personViewSource.Source as ICollection<Person>;

			//foreach(var item in HeleleSet)
			//{
			//	MessageBox.Show(item.ToString());
			//}
		}
	}
}
