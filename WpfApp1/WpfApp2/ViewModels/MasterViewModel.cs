using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp2.Messages;

namespace WpfApp2.ViewModels
{
	public partial class MasterViewModel
		: ObservableObject, IRecipient<string>
	{
		//data field--store service -readonly
		private string _data;
	    //property--excute service restircs only getMethod
		public string Data
		{
			get => _data;
			set
			{
				if (SetProperty(ref _data, value))
				{
					// 데이터가 변경될 때 StrongReferenceMessenger를 이용하여 메시지 발행
					StrongReferenceMessenger.Default.Send(new DataMessage(_data)); // global
				}
			}
		}

		public void Receive(string message)
		{
			throw new NotImplementedException();
		}

		public MasterViewModel()
		{
			Data = "Master 초기 데이터";
		}
	}
}
