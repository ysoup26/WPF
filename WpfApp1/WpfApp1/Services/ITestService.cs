using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
	public interface ITestService
	{
		public ObservableCollection<Person> GetPeople();
	}
	public partial class UsersService : ITestService
	{
		public ObservableCollection<Person> GetPeople()
		=> [
				new Person{Id=1, Age=11, Address="seoul",Gender=true,Irum="leebok1",Telephone="1234-5678"},
				new Person{Id=2, Age=22, Address="busan",Gender=false,Irum="leebok2",Telephone="2344-5678"},
				new Person{Id=3, Age=33, Address="daegu",Gender=true,Irum="leebok3",Telephone="3444-5678"},
				new Person{Id=4, Age=44, Address="kwangju",Gender=true,Irum="leebok4",Telephone="5644-5678"},
				new Person{Id=5, Age=55, Address="inchun",Gender=true,Irum="leebok5",Telephone="5234-5678"},
				new Person{Id=6, Age=66, Address="jaeju",Gender=true,Irum="leebok6",Telephone="5644-5678"},
			];
	}
}
