using System;

namespace Chatroom.Chat
{
	public class TextChatter : IChatter
	{
		public string Alias { get; set; }
		
		public TextChatter(string alias)
		{
			Alias = alias;
		}

		public void ReceiveAMessage(string msg, IChatter c)
		{
			Console.WriteLine("(At " + Alias + ") : " + c.Alias + " $> " + msg);
		}
	}
}