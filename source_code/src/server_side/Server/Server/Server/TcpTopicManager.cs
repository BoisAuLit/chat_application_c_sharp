using System;
using System.Linq;
using System.Text;
using System.Threading;
using Chatroom.Chat;
using Protocol;

namespace Chatroom.Server
{
	public class TcpTopicManager : TextTopicManager
	{
		public static int NextPort = 11002;

		public new string ListTopics()
		{
			var topicStrings = Topics.Keys;
			var lastItem = topicStrings.Last();
			var sb = new StringBuilder();
			sb.Append("({<");
			foreach (var v in topicStrings)
				if (v.Equals(lastItem))
					sb.Append(v + ">,<");
				else
					sb.Append(v + ">})");
			return sb.ToString();
		}


		// Every time that there is a topic change, we send message to clients
		private static void InformTopic(Protocol.Message message)
		{
			foreach (var stm in ServerManager.ClonedServerTopicManagers.Values)
			{
				stm.SendMessage(message);
			}
		}

		public new void CreateTopic(string topic)
		{
			// If topic already exists, we don't create it
			if (Topics.ContainsKey(topic))
			{
				Console.WriteLine("Topic " + topic + " already exists!");
				return;
			}

			// Every time we create a main server chat rooms that listen for connection requests
			// We should also create a text chat room associated with it
			var chatroom = new ServerChatroom
			{
				Topic = topic,
				ConcreteChatroom = new TextChatroom(topic)
			};
			chatroom.ConcreteChatroom = new TextChatroom(topic);
			ServerManager.MainServerChatrooms.Add(topic, chatroom);

			// Add the topic and the newly created ServerChatroom to the dictionary
			Topics.Add(topic, chatroom);

			// Start the ServerChatroom
			chatroom.StartServer(NextPort++);
			new Thread(chatroom.Run).Start();
			
			var topicCreatedMessage = new Protocol.Message
			{
				Header = HeaderType.NEW_TOPIC_CREATED
			};
			topicCreatedMessage.Arguments.AddLast(topic);
			InformTopic(topicCreatedMessage);
		}
	}
}