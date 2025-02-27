using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public partial class User: ObservableObject
	{
		//[ObservableProperty]
		public int Id { get; set; }

		//[ObservableProperty]
		public string Irum { get; set; } 

		//[ObservableProperty]
		public int Age { get; set; }
	}
}
