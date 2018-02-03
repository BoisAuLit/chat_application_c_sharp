using Protocol;

namespace Chatroom.Net
{
	// Classes that implement this interface should be able to send and receive messages
	public interface IMessageConnection
	{
		// Get message that is sent to the current server
		Message GetMessage();
		
		// Send message to remote end point
		void SendMessage(Message message);
	}
}