using System;
using System.Collections.Generic;
using System.Net;
using Chatroom.Chat;
using Chatroom.Net;
using Protocol;
using System.Linq;

namespace Chatroom.Client
{
	public class ClientTopicManager : TcpClient
	{
		public string FailureMessage;
	}
}