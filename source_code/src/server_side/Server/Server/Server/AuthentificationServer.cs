using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using Chatroom.Authentification;
using Chatroom.GUI;
using Chatroom.Net;
using Protocol;

namespace Chatroom.Server
{
	public class AuthentificationServer : TcpServer
	{
		// ReSharper disable once FieldCanBeMadeReadOnly.Local
		private static AuthentificationDatabase _ad = new AuthentificationDatabase();

		public static Dictionary<string, User> Users { get; set; }

		public AuthentificationServer()
		{
			Users = _ad.Users;
		}

		// Mange conneciton authentification request from server side
		public override void ManageClient()
		{
			while (true)
			{
				var message = GetMessage();

				// ReSharper disable once SwitchStatementMissingSomeCases
				switch (message.Header)
				{
					case HeaderType.AUTHENTIFICATION_REQUEST:

						// Retrieve user name & password from the request message
						var userName = message.Arguments.ElementAt(0);
						var password = message.Arguments.ElementAt(1);
						SecureString ps = new NetworkCredential("", password).SecurePassword;

						var msg = new Message
						{
							Header = HeaderType.AHTHENTIFICATION_REPLY
						};

						// Forbid several users connecting with the same login
						if (ServerManager.ActiveUsers.Contains(userName))
						{
							msg.Arguments.AddLast("failure");
							msg.Arguments.AddLast("User already logged in");
							WindowsManager.Af.AddLog(msg.ToString());
							SendMessage(msg);
							return;
						}

						// If authentification okay
						if (_ad.Authentify(userName, ps))
						{
							// If validation is okay, reply to client with a message
							// containg the main server topic manager
							ServerManager.ActiveUsers.AddLast(userName);
							msg.Arguments.AddLast("success");
							msg.Arguments.AddLast("" + ServerManager.Stm.PortNumber);
							
							Console.WriteLine("Validation okay");
							Console.WriteLine("\tHere, the port is: " + ServerManager.Stm.PortNumber);
							Console.WriteLine("\tServer.Stm is null?: " + (ServerManager.Stm == null));

							WindowsManager.Af.AddClient(userName + "@" + CommSocket.RemoteEndPoint.ToString());

							SendMessage(msg);
							// When authentification is okay, close the current authentification server
							OnExit();
							// End the loop
							return;
						}
						// If authentification not okay
						else { 

							Console.WriteLine("Validation not okay!");
							msg.Arguments.AddLast("failure");

							WindowsManager.Af.AddLog("Validation of " + userName + " not okay");
							WindowsManager.Af.AddLog("And the failure reason is: " + _ad.FailureMessage);

							msg.Arguments.AddLast(_ad.FailureMessage);
							SendMessage(msg); 
						}
						break;
					case HeaderType.EXIT:
						// When user quits, close the current authentificaiton server
						OnExit();
						return;
					default:
						throw new Exception("Header type not correct in AuthentificationServer class");
				}
			}
		}
		
		private void OnExit()
		{
			// Stop and close the current AuthentificationServer
			StopServer();
			// Remove this AuthentificationServer's reference from the list
			// so that memory allocated to this server will eventually be released
			ServerManager.ClonedAuthentificationServers.Remove(RemoteEp);
		}

		public override object Clone()
		{
			// To be implemented later if needed
			var copy = new AuthentificationServer
			{
				CommSocket = CommSocket,
				RemoteEp = RemoteEp
			};
			ServerManager.ClonedAuthentificationServers.Add(RemoteEp, copy);			
			return copy;
		}
	}
}
