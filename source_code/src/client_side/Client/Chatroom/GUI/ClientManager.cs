using Chatroom.Chat;
using Chatroom.Client;
using System.Net;

namespace Chatroom.GUI
{
	class ClientManager
	{
		public static AuthentificationClient Ac { get; set; }
		public static ClientChatroom Cc { get; set; }
		public static ClientTopicManager Ctm { get; set; }
		public static TextChatter Chatter { get; set; }
		public static IPAddress ServerIP { get; set; }
		public static int AuthentificationServerPort { get; set; }
		public static int ServerTopicManagerPort { get; set; }
		public static int ServerChatroomPort { get; set; }
		public static string SelectedTopic { get; set; }
	}
}
