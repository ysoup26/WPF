using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
	public partial class Window1ViewModel : ObservableCollection<PeopleItem>
	{
		//		<SampleDataSource:PeopleItem Id = "99" Age="19" Irum="Aaberg, Jesper" Telephone="(111) 555-0100" Address="4567 Main St., Buffalo, NY 98052"/>
		//<SampleDataSource:PeopleItem Id = "87" Age="21" Irum="Adams, Ellen" Telephone="(222) 555-0101" Address="1234 Main St., Buffalo, NY 98052"/>
		//<SampleDataSource:PeopleItem Id = "76" Age="79" Irum="Adams, Terry" Telephone="(333) 555-0102" Address="2345 Main St., Buffalo, NY 98052"/>

		public Window1ViewModel()
		{
			Add(new() { 
				Id = 99, 
				Age = 19,
				Irum = "Aaberg, Jesper",
				Telephone = "(111) 555-0100", 
				Address = "4567 Main St., Buffalo, NY 98052" 
			});
			Add(new()
			{
				Id = 87,
				Age = 21,
				Irum = "Adams, Ellen",
				Telephone = "(222) 555-0100",
				Address = "1234 Main St., Buffalo, NY 98052"
			});
			Add(new()
			{
				Id = 76,
				Age = 79,
				Irum = "Adams, Terry",
				Telephone = "(333) 555-0100",
				Address = "2345 Main St., Buffalo, NY 98052"
			});
		}
	}
	
}
