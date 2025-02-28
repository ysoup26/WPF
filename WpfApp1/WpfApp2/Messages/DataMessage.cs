using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WpfApp2.Messages
{
	//define message Type
	public partial class DataMessage
		: ValueChangedMessage<string>
	{
		//messager base injetion service
		public DataMessage(string value)
			: base(value)
		{
		}
	}
	////define message Type
	//public partial record class DataMessage
	//	: ValueChangedMessage<string>
	//{
	//	//messager base injetion service
	//	public DataMessage(string value)
	//		: base(value)
	//	{
	//	}
	//}
}

