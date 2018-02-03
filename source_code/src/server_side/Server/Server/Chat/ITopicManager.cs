using System.Collections.Generic;

namespace Chatroom.Chat
{
	public interface ITopicManager
	{
		Dictionary<string, IChatroom> Topics { get; set; }
		
		void ListTopics();
		
		IChatroom JoinTopic(string topic);
		
		/// <exception cref="TopicExistentException">Throws when creating
		///  a topic, but the topic already exists</exception>
		void CreateTopic(string topic);
	}
}