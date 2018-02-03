using System;
using System.Linq;
using System.Net;
using Chatroom.Chat;
using Chatroom.Net;
using Protocol;

namespace Chatroom.Client
{
	public class ClientChatroom : TcpClient
	{
		public IChatter Chatter { get; set; }
	}
}