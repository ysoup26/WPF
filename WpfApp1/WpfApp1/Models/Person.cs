using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	//C# model ===> wpf model : Notify를 추가해야함
	public partial class Person : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			//local delegate service
			PropertyChangedEventHandler? imsi = PropertyChanged;

			//C# 6.0 later
			imsi?.Invoke(this,new PropertyChangedEventArgs(propertyName));

			//C# 8.0 later !가 추가됨 null에 대해서 runtime에서 확인
			//imsi!.Invoke(this,new PropertyChangedEventArgs(propertyName));

			//C# 1.0 level
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public bool Gender
		{
			get => field;
			set
			{
				field = value;
				this.OnPropertyChanged("Gender");
			}
		}
		//private double _Id = 0;

		public double Id
		{
			get => field;

			set
			{
				if (field != value)
				{
					field = value;
					this.OnPropertyChanged("Id");
				}
			}
		}

		private double _Age = 0;

		public double Age
		{
			get => field;
			//{
			//	return this._Age;
			//}

			set
			{
				//if (this._Age != value)
				if (field != value)
				{
					field = value;
					this.OnPropertyChanged("Age");
				}
			}
		}

		// private string _Irum = string.Empty;

		//Partial Property :선언(declare)
		//[ObserverProperty] //toolkit사용할때
		public partial string Irum { get; set; }

		//source-generation service
		public partial string Irum //implementation
		{
			get => field;
			//{
			//	return this._Irum;
			//}

			set
			{
				if (field != value)
				{
					field = value;
					this.OnPropertyChanged("Irum");
				}
			}
		}

		private string _Telephone = string.Empty;

		public string Telephone
		{
			get
			{
				return this._Telephone;
			}

			set
			{
				if (this._Telephone != value)
				{
					this._Telephone = value;
					this.OnPropertyChanged("Telephone");
				}
			}
		}

		private string _Address = string.Empty;

		public string Address
		{
			get
			{
				return this._Address;
			}

			set
			{
				if (this._Address != value)
				{
					this._Address = value;
					this.OnPropertyChanged("Address");
				}
			}
		}


	}
}
