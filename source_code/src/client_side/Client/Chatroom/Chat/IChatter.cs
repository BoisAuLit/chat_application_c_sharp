namespace Chatroom.Chat
{
	public interface IChatter
	{
		string Alias { get; set; }
		
		void ReceiveAMessage(string msg, IChatter c);
	}
}