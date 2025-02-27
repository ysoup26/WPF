//      *********    이 파일을 수정하지 마십시오.     *********
//      이 파일은 디자인 도구에서 다시 생성했습니다. 이 파일을
//      변경하면 오류가 발생할 수 있습니다.
namespace Expression.Blend.SampleData.SampleDataSource
{
    using System; 
    using System.ComponentModel;

// 프로덕션 애플리케이션에서 예제 데이터 공간을 대폭 줄이려면
// 런타임에 DISABLE_SAMPLE_DATA 조건부 컴파일 상수를 설정하고 예제 데이터를 사용하지 않도록 설정하면 됩니다.
#if DISABLE_SAMPLE_DATA
    internal class SampleDataSource { }
#else

    public class SampleDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SampleDataSource()
        {
            try
            {
                Uri resourceUri = new Uri("SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
                System.Windows.Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private People _People = new People();

        public People People
        {
            get
            {
                return this._People;
            }
        }
    }

    public class PeopleItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private double _Id = 0;

        public double Id
        {
            get
            {
                return this._Id;
            }

            set
            {
                if (this._Id != value)
                {
                    this._Id = value;
                    this.OnPropertyChanged("Id");
                }
            }
        }

        private double _Age = 0;

        public double Age
        {
            get
            {
                return this._Age;
            }

            set
            {
                if (this._Age != value)
                {
                    this._Age = value;
                    this.OnPropertyChanged("Age");
                }
            }
        }

        private string _Irum = string.Empty;

        public string Irum
        {
            get
            {
                return this._Irum;
            }

            set
            {
                if (this._Irum != value)
                {
                    this._Irum = value;
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

    public class People : System.Collections.ObjectModel.ObservableCollection<PeopleItem>
    { 
    }
#endif
}
