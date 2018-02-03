using System;

namespace Chatroom.Chat
{
	public class TopicExistentException : Exception
	{
		public string Topic { get; set; }

		public TopicExistentException(string topic)
		{
			Topic = topic;
		}
		
		public override string ToString()
		{
			return "Topic " + Topic + " already exists: " + base.ToString();
		}
	}
}