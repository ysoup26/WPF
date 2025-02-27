using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
		//public MainWindow()
		//{
		//    InitializeComponent();
		//}
		public MainWindow(MainViewModel vm)
		{
			InitializeComponent();
			DataContext = vm;
		}
	}
}
