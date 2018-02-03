using System;

namespace Chatroom.Chat
{
	public class TopicInExistentException : Exception
	{
		public string Topic { get; set; }

		public TopicInExistentException(string topic)
		{
			Topic = topic;
		}
		
		public override string ToString()
		{
			return "Topic " + Topic + " does not exist: " + base.ToString();
		}
	}
}