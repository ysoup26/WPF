using System.ComponentModel;

namespace WpfApp2.Models
{
	public partial class Person : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			//local delegate service
			PropertyChangedEventHandler imsi = PropertyChanged;

			//C# 6.0 later
			imsi?.Invoke(this, new PropertyChangedEventArgs(propertyName));

			//C# 8.0 later !가 추가됨 null에 대해서 runtime에서 확인
			//imsi!.Invoke(this,new PropertyChangedEventArgs(propertyName));

			//C# 1.0 level
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private double id = 0;

		public double Id
		{
			get => id;

			set
			{
				//if (_id != value)
				//{
					id = value;
					this.OnPropertyChanged("Id");
				//}
			}
		}

		private double age = 0;

		public double Age
		{
			get => age;
			//{
			//	return this._Age;
			//}

			set
			{
				//if (this._Age != value)
				//if (_age != value)
				//{
					age = value;
					this.OnPropertyChanged("Age");
				//}
			}
		}

		private string irum = string.Empty;

		//Partial Property :선언(declare)
		//[ObserverProperty] //toolkit사용할때
		//public string Irum { get; set; }

		//source-generation service
		public string Irum //implementation
		{
			get => irum;
			//{
			//	return this.Irum;
			//}

			set
			{
				//if (field != value)
				//{
				irum = value;
					this.OnPropertyChanged("Irum");
				//}
			}
		}

		private string telephone = string.Empty;

		public string Telephone
		{
			get => telephone;

			set
			{
				//if (this._Telephone != value)
				//{
					this.telephone = value;
					this.OnPropertyChanged("Telephone");
				//}
			}
		}

		private string address = string.Empty;

		public string Address
		{
			get => address;

			set
			{
				//if (this._Address != value)
				//{
					this.address = value;
					this.OnPropertyChanged("Address");
				//}
			}
		}
		private bool gender;

		public bool Gender
		{
			get => gender;
			set 
			{ 
				gender = value;
				this.OnPropertyChanged("Gender");
			}
		}
		public override string ToString()
		{
			return $"Id:{Id} Age:{Age} Irum:{Irum} Gender:{Gender} Telephone:{Telephone} Address:{Address}";
		}

	}
}
