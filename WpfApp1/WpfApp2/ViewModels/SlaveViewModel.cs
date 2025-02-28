using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Messages;

namespace WpfApp2.ViewModels
{
	public partial class SlaveViewModel
		: ObservableObject, IRecipient<DataMessage>, IDisposable
	{
		private static readonly Lazy<SlaveViewModel> _instance = new(() => new SlaveViewModel()); //immutable service field
		
		//immutable service ... readobly property expression
		public static SlaveViewModel Instance => _instance.Value; //lambda expression

		//c# 13.0 field keyword service...backing store - stream
		private string _receivedData;
		public string ReceivedData
		{
			get => _receivedData;
			set => SetProperty(ref _receivedData, value);
		}

		private SlaveViewModel()
		{
			StrongReferenceMessenger.Default.Register<DataMessage>(this);
		}

		public void Receive(DataMessage message)
		=> ReceivedData = message.Value;

		public void Dispose()
		=> StrongReferenceMessenger.Default.Unregister<DataMessage>(this);
	}
}
