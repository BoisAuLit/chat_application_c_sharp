using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace Chatroom.Server
{
	// A mangager that controls all the servers
	public static class ServerManager
	{
		public static Dictionary<IPEndPoint, AuthentificationServer> ClonedAuthentificationServers;
		public static Dictionary<string, ServerTopicManager> ClonedServerTopicManagers;
		public static Dictionary<string, ServerChatroom> MainServerChatrooms;
		public static Dictionary<string, ServerChatroom> ClonedServerChatrooms;

		// Static constructor, invoked when the class is loaded in memory
		static ServerManager()
		{
			MainServerChatrooms = new Dictionary<string, ServerChatroom>();
			ClonedServerChatrooms = new Dictionary<string, ServerChatroom>();
			ClonedServerTopicManagers = new Dictionary<string, ServerTopicManager>();
			ClonedAuthentificationServers = new Dictionary<IPEndPoint, AuthentificationServer>();
		}
		
		private const int DefaultMainAuthentificationServerPort = 11000;
		private const int DefaultMainServerTopicManagerPort = 11001;
		
		private static AuthentificationServer _as;
		public static void StartServer()
		{
			_as = new AuthentificationServer();
			_as.StartServer(DefaultMainAuthentificationServerPort);
			new Thread(_as.Run).Start();
		}

		// Main ServerTopicManager who listens for connecting requests
		private static ServerTopicManager _stm;
		public static ServerTopicManager Stm
		{
			get
			{
				if (_stm != null)
					return _stm;
				_stm = new ServerTopicManager {ConcretTopicManager = new TcpTopicManager()};
				// User random port to start server
				_stm.StartServer(DefaultMainServerTopicManagerPort);
				new Thread(_stm.Run).Start();
				return _stm;
			}
		}

		// Stop the main AuthentificationServer and the main ServerTopicManager
		// and the main ServerChatrooms
		public static void StopServer()
		{
			_as.StopServer();
			_stm.StopServer();
			foreach (var mainChatroom in MainServerChatrooms.Values)
				mainChatroom.StopServer();
		}

		public static LinkedList<string> ActiveUsers { get; set; } = new LinkedList<string>();
	}
}