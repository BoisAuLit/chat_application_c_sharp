using System;
using System.Collections.Generic;

namespace Chatroom.Chat
{
	public class TextChatroom : IChatroom
	{
		public string Topic { get; set; }
		
		public List<IChatter> Participants { get; set; }

		public TextChatroom (string topic)
		{
			Topic = topic;
			Participants = new List<IChatter>();
		}
		
		public void Post(string msg, IChatter c)
		{
			foreach (IChatter chatter in Participants)
				chatter.ReceiveAMessage(msg, c);
		}

		public void Quit(IChatter c)
		{
			Participants.Remove(c);
		}

		public void Join(IChatter c)
		{
			Console.WriteLine("(Message form chatroom :" + Topic + ") " + c.Alias + " has joined the room.");
			Participants.Add(c);
		}
	}
}