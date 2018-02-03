using System;
using System.Collections.Generic;
using System.Linq;
using Chatroom.Chat;
using Chatroom.Net;
using Protocol;
using Chatroom.GUI;

namespace Chatroom.Server
{
	public sealed class ServerTopicManager : TcpServer, ITopicManager
	{
		public TcpTopicManager ConcretTopicManager { get; set; }
		// A topic manager controll all the chat rooms

		// Manage all the existent chat rooms
		public Dictionary<string, IChatroom> Topics { get; set; }

		public string Alias { get; set; }

		// The concrete topic manager list all the topics
		public void ListTopics()
		{
			ConcretTopicManager.ListTopics();
		}

		public IChatroom JoinTopic(string topic)
		{
			return ConcretTopicManager.JoinTopic(topic);
		}

		public void CreateTopic(string topic)
		{
			ConcretTopicManager.CreateTopic(topic);
		}

		public override void ManageClient()
		{
			while (true)
			{
				var message = GetMessage();
				switch (message.Header)
				{
					case HeaderType.LIST_TOPICS:
						// Send message to client side
						var msg = new Message
						{
							Header = HeaderType.LIST_TOPICS_REPLY,
						};
						this.Alias = message.Arguments.ElementAt(0);

						ServerManager.ClonedServerTopicManagers.Add(Alias, this);

						if (ConcretTopicManager.Topics.Count != 0)
						{
							foreach (var v in ConcretTopicManager.Topics.Keys)
							{
								msg.Arguments.AddLast(v);
							}
						}
						SendMessage(msg);
						break;
					case HeaderType.CREATE_TOPIC:

						string topicToBeCreated = message.Arguments.ElementAt(0);

						var createTopicReply = new Message
						{
							Header = HeaderType.CREATE_TOPIC_REPLY
						};

						if (ConcretTopicManager.Topics.Keys.Contains(topicToBeCreated))
						{
							// The topic to be created already exists
							createTopicReply.Arguments.AddLast("failure");
							createTopicReply.Arguments.AddLast("Topic already exists");
						}
						else
						{
							// Successfully created a topic
							createTopicReply.Arguments.AddLast("success");
							ConcretTopicManager.CreateTopic(topicToBeCreated);
							WindowsManager.Af.AddChatroom(topicToBeCreated);
						}

						SendMessage(createTopicReply);

						break;
					case HeaderType.JOIN_TOPIC:
						string topicToJoin = message.Arguments.ElementAt(0);
						// If topic does not exist, then throw error

						var joinReply = new Message
						{
							Header = HeaderType.JOIN_TOPIC_REPLY
						};
						if (!ConcretTopicManager.Topics.Keys.Contains(topicToJoin))
						{
							joinReply.Arguments.AddLast("failure");
							joinReply.Arguments.AddLast("The topic doesn't exist anymore");
							SendMessage(joinReply);

							// If failed to join a topic, then continue the loop
							continue;
						}
						else
						{
							var chatroom = ConcretTopicManager.Topics[topicToJoin];
							var portNumber = ((ServerChatroom) chatroom).PortNumber;
							joinReply.Arguments.AddLast("success");
							joinReply.Arguments.AddLast("" + portNumber);
							SendMessage(joinReply);
							// When successfully joining a topic, close the current ServerTopicManager
							//OnExit();
						}
						break;
					case HeaderType.EXIT:
						//OnExit();
						return;
					default:
						throw new Exception("Header type not correct or message cannot be handled!");
				}
			}
		}

		private void OnExit()
		{
			StopServer();
			ServerManager.ClonedServerTopicManagers.Remove(Alias);
		}

		public override object Clone()
		{
			var copy = new ServerTopicManager
			{
				CommSocket = CommSocket,
				ConcretTopicManager = ConcretTopicManager,
				RemoteEp = RemoteEp
			};
			return copy;
		}
	}
}