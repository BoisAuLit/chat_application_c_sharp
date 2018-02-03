using System.Collections.Generic;

namespace Chatroom.Chat
{
	public interface IChatroom
	{
		string Topic { get; set; }
		
		// All the chatters that are in this chat room
		List<IChatter> Participants { get; set; }
		
		void Post(string msg, IChatter c);
		
		void Quit(IChatter c);
		
		void Join(IChatter c);
		
	}
}