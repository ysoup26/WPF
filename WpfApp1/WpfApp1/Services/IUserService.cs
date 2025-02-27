using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
	public interface IUserService
	{
		public Person GetPerson();
		public void SetPerson(Person p);
	}

	//중복된 것은 서비스로 뽑아내자
	//service provider
	public partial class UserService : IUserService
	{
		private Person person;

		public Person GetPerson()
		=> person;

		public void SetPerson(Person p)
		{
			person = p;
		}
	}
}
