using System;
using System.Collections.Generic;

namespace Chatroom.Chat
{
	public class TextTopicManager : ITopicManager
	{
		public Dictionary<string, IChatroom> Topics { get; set; }

		public TextTopicManager()
		{
			Topics = new Dictionary<string, IChatroom>();
		}
		
		public virtual void ListTopics()
		{
			Console.Write("Topics: ");
			foreach (string topic in Topics.Keys)
				Console.Write(topic + " ");
			Console.WriteLine("\n");
		}

		public IChatroom JoinTopic(string topic)
		{
			if (!Topics.ContainsKey(topic))
				throw new TopicInExistentException(topic);
			return Topics[topic];
		}

		public void CreateTopic(string topic)
		{
			if (Topics.ContainsKey(topic))
				throw new TopicExistentException(topic);
			Topics.Add(topic, new TextChatroom(topic));
		}
	}
}