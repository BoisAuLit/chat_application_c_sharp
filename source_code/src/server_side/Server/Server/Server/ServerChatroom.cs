using System;
using System.Collections.Generic;
using System.Linq;
using Chatroom.Chat;
using Chatroom.Net;
using Protocol;

namespace Chatroom.Server
{
	// A ServerChatroom represents a unique client
	public sealed class ServerChatroom : TcpServer, IChatter, IChatroom
	{
		public string Alias { get; set; }
		public IChatroom ConcreteChatroom { get; set; }
		public ITopicManager MyTopicManager { get; set; } // To be deleted
		public string Topic { get; set; }
		public List<IChatter> Participants { get; set; } // To be deleted
		
		
		// Receive a message from client side
		public void ReceiveAMessage(string msg, IChatter c)
		{
			var message = new Message
			{
				Header =  HeaderType.RECV_MSG,
			};
			message.Arguments.AddLast(msg);
			message.Arguments.AddLast(c.Alias);
			
			// Send the message from server side to client side
			SendMessage(message);
		}

		// Implemented from IChatroom
		public void Post(string msg, IChatter c)
		{
			Console.WriteLine("ConcreteChatroom is null ? :" + (ConcreteChatroom == null));
			
			// Use the concrete chatroom to do the concrete thing
			// The instance of this class is just a dispatcher
			ConcreteChatroom.Post(msg, c);
		}

		// Implemented from IChatroom
		public void Quit(IChatter c)
		{
			// Use the concrete chatroom to do the concrete thing
			ConcreteChatroom.Quit(c);
		}

		// Implemented from IChatroom
		public void Join(IChatter c)
		{	
			ConcreteChatroom.Join(c);
		}

		public override void ManageClient()
		{	
			// Receiving messages in a loop
			while (true)
			{
				var message = GetMessage();
				
				switch (message.Header)
				{
					case HeaderType.JOINCR:
						Console.WriteLine("Message join chatroom received");
						Alias = message.Arguments.ElementAt(0);
						ServerManager.ClonedServerChatrooms.Add(Alias, this);
						// Put the current chatter in the List of the concrete chat room
						Join(this);
						break;
					case HeaderType.POST:
						string msg = message.Arguments.ElementAt(0);
						Post(msg, this);
						break;
					case HeaderType.QUITCR:
						// When client quit the current chat room, then stop the current chat room server
						Quit(this);
						OnExit();
						break;
					// Code to be added in the near future
					case HeaderType.EXIT:
						OnExit();
						return;
					default:
						throw new Exception("Wrong header type exception in class ServerChatroom!");
				}
			}
		}

		private void OnExit()
		{
			// Stop and close the current AuthentificationServer
			StopServer();
			// Remove this AuthentificationServer's reference from the list
			// so that memory allocated to this server will eventually be released
			ServerManager.ClonedServerChatrooms.Remove(Alias);
		}

		public override object Clone()
		{
			var copy = new ServerChatroom()
			{
				CommSocket = CommSocket,
				ConcreteChatroom = ConcreteChatroom,
				Topic = Topic
			};
			return copy;
		}
	}
}