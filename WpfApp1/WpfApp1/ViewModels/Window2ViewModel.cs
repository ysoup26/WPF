using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; //Blend-Input...behavior.trigger.event
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
	public partial class Window2ViewModel: ObservableObject//:ObservableCollection<string>
	{
		[ObservableProperty]
		public partial string MyProperty2 { get; set; } // C# 13.0 later


		//C# 6.0 readonly-property...exoression service...immutable service
		[ObservableProperty]  // old version - attribute vs new version - decorate
		public partial string MyProperty { get;set; } // C# 13.0 later
		//public string myProperty;// Field-store service{ get; set; }
		//	=> "Hello exoression service...immutable service";

		[ObservableProperty]
		public partial string MyProperty3 { get; set; } 


		//[RelayCommand]
		//public string MyMethod() 
		//	=> "Hello exoression service...immutable service";

		[RelayCommand]
		public void DisplayMessage(object msg) => MessageBox.Show($"Hai....{msg}"); //수식이 아니면 이걸써라. 수식만이 연산을 하도록
		[RelayCommand]
		public void DisplayMessage2(object msg) => MessageBox.Show($"Hai2....{msg}"); //수식이 아니면 이걸써라. 수식만이 연산을 하도록
		[RelayCommand]
		public void DisplayMessage3(object msg) => MessageBox.Show($"Hai3....{msg}"); //수식이 아니면 이걸써라. 수식만이 연산을 하도록

		/*길었던 Command가 Toolkit을 통해 단순해짐*/
		//public ICommand HeleleCommand //{ get; private set; } //property
		//{
		//	get
		//	{
		//		if(heleleCommand == null)
		//		{
		//			heleleCommand = new RelayCommand(DisplayMessage);
		//		}
		//		return heleleCommand;
		//	}
		//}
		//public ICommand heleleCommand2; //store service
		////C# 6.0 upgrade...property-excpression
		//public ICommand HeleleCommand2 //{ get; private set; }
		//=> heleleCommand2 = heleleCommand2 ?? new RelayCommand(DisplayMessage);
		////public ICommand HeleleCommand2 { get; private set; }

		////C# 8.0 ??= immutable service
		//public ICommand heleleCommand3;
		//public ICommand HeleleCommand3 //{ get; private set; }
		//	=> heleleCommand3 ??= new RelayCommand(DisplayMessage);

		public Window2ViewModel()
		{
			MyProperty = "Hello exoression service...immutable service";
			MyProperty2 = "partial property service...toolkit service...wa~~~wooo";
			MyProperty3 = "MyProperty3";
			//HeleleCommand = new HeleleCommandClass(this); // dependency-injection
			//HeleleCommand = new RelayCommand(DisplayMessage); // dependency-injection
			//HeleleCommand2 = new HeleleCommandClass2(this); // dependency-injection
			//HeleleCommand2 = new RelayCommand(DisplayMessage); // dependency-injection
			//HeleleCommand3 = new HeleleCommandClass3(this); // dependency-injection
			//HeleleCommand3 = new RelayCommand(DisplayMessage); // dependency-injection
		}

		//presentation-logic...prototype...action delegate...func delegate :: relayCommand(이벤트만 하면)
		// ...func delegate...delegateCommand()


	}

	//broker service...internedate service...DI/IoC...SOLID
	public class HeleleCommandClass : ICommand
	{
		//...interface service...c# injector(클래스와 클래스의 관계) vs selector vs pointer
		Window2ViewModel imsi;

		//injection
		public HeleleCommandClass(Window2ViewModel imja)
		{
			imsi = imja;
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter) => true;
		//{
		//	throw new NotImplementedException();
		//}

		public void Execute(object? parameter)
		{
			imsi.DisplayMessage(parameter);
			//MessageBox.Show("Hai");
			//throw new NotImplementedException();
		}
	}
	public class RelayCommand : ICommand
	{
		//...interface service...c# injector(클래스와 클래스의 관계) vs selector vs pointer
		Action<object> imsi;

		//injection
		public RelayCommand(Action<object> imja)
		{
			imsi = imja;
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter) => true;
		//{
		//	throw new NotImplementedException();
		//}

		public void Execute(object? parameter)
		{
			imsi(parameter);
			//imsi.DisplayMessage(parameter); :비용이 비싼 방식
			//MessageBox.Show("Hai"); : Command에서 View수행을 하는 것은 옳지 않음
			//throw new NotImplementedException();
		}
	}

	public class HeleleCommandClass2 : ICommand
	{
		//...interface service...c# injector(클래스와 클래스의 관계) vs selector vs pointer
		Window2ViewModel imsi;

		//injection
		public HeleleCommandClass2(Window2ViewModel imja)
		{
			imsi = imja;
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter) => true;
		//{
		//	throw new NotImplementedException();
		//}

		public void Execute(object? parameter)
		{
			imsi.DisplayMessage(parameter);
			//MessageBox.Show("Hai");
			//throw new NotImplementedException();
		}
	}

	public class HeleleCommandClass3 : ICommand
	{
		//...interface service...c# injector(클래스와 클래스의 관계) vs selector vs pointer
		Window2ViewModel imsi;

		//injection
		public HeleleCommandClass3(Window2ViewModel imja)
		{
			imsi = imja;
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter) => true;
		//{
		//	throw new NotImplementedException();
		//}

		public void Execute(object? parameter)
		{
			imsi.DisplayMessage(parameter);
			//MessageBox.Show("Hai");
			//throw new NotImplementedException();
		}
	}
}
