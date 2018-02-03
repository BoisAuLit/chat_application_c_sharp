using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Protocol;
using Chatroom.GUI;

namespace Chatroom.Net
{
	public enum ServerMode
	{
		TreatClient,
		NotTreatClient
	}

	public abstract class TcpServer : IMessageConnection, ICloneable, IRunnable
	{
		private Socket _waitSocket;
		protected Socket CommSocket;

		// Thread signals.
		private ManualResetEvent _connectDone = new ManualResetEvent(false);
		private ManualResetEvent _receiveDone = new ManualResetEvent(false);
		private ManualResetEvent _sendDone = new ManualResetEvent(false);

		private Message _messageReceived;

		// All related activities relevant to the current server is done
		private bool _everythingDone;

		// The mode of the server, default value is "NotTreatClient
		protected ServerMode ServerMode { get; set; } = ServerMode.NotTreatClient;

		public int PortNumber { get; set; }

		// The remote end point associated to the current server
		protected IPEndPoint RemoteEp;
		public IPEndPoint LocalEp;

		public static int NextPort = 11002;

		// Start server at a givin port
		public void StartServer(int port)
		{
			PortNumber = port;
			var endPoint = new IPEndPoint(IPAddress.Any, port);
			// Start local server at given port
			_waitSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			// Bind the socket to the local endpoint and listen for incoming connections.
			try
			{
				_waitSocket.Bind(endPoint);
				// All at most 100 connections
				_waitSocket.Listen(100);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		public void Run()
		{
			if (ServerMode == ServerMode.TreatClient)
				ManageClient();
			else
			{
				while (true)
				{
					try
					{
						// Set the event to nonsignaled state.
						_connectDone.Reset();

						// Start an asynchronous socket to listen for connections
						Console.WriteLine("Waiting for a connection...");
						_waitSocket.BeginAccept(AcceptCallback, null);
						// Thread will continue after user connection is done

						_connectDone.WaitOne();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.ToString());
					}

					if (_everythingDone)
						return;
					var myClone = (TcpServer)Clone();
					myClone.ServerMode = ServerMode.TreatClient;

					new Thread(myClone.Run).Start();
				}
			}
		}

		private void AcceptCallback(IAsyncResult ar)
		{
			if (_everythingDone)
				return;
			// Signal the main thread int the StartServer() method to continue
			// listining so that it can accpet connection requests
			CommSocket = _waitSocket.EndAccept(ar);

			// Set LocalEp & RemoteEp property
			LocalEp = (IPEndPoint)CommSocket.LocalEndPoint;
			RemoteEp = (IPEndPoint)CommSocket.RemoteEndPoint;
			Console.WriteLine("Remote client at " + CommSocket.RemoteEndPoint + " connected");
			Console.WriteLine("The socket's local end point is " + CommSocket.LocalEndPoint);
			_connectDone.Set();
		}

		// Get message (string type) from the socket
		public Message GetMessage()
		{
			try
			{
				_receiveDone.Reset();
				var state = new StateObject();
				CommSocket.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);

				// Wait until the receiving procedure is done
				_receiveDone.WaitOne();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}

			return _messageReceived;
		}

		private void ReceiveCallback(IAsyncResult ar)
		{
			try
			{
				// Retrieve the state object and the client socket 
				// from the asynchronous state object.
				var state = (StateObject)ar.AsyncState;
				// Read data from the remote device.
				var bytesRead = CommSocket.EndReceive(ar);

				if (bytesRead <= 0) return;

				// There  might be more data, so store the data received so far.
				state.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

				// Check for end-of-file tag. If it is not there, read more data.
				var content = state.Sb.ToString();
				if (content.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
				{
					// ReSharper disable once SuggestVarOrType_SimpleTypes
					JMessage jm = JMessage.Deserialize(content.Replace("<EOF>", ""));
					_messageReceived = jm.Value.ToObject<Message>();

					// Display the message received
					Console.WriteLine("\nServer received message from client: " + _messageReceived + "\n");

					WindowsManager.Af.AddLog("\tServer received message from client:\r\n" + _messageReceived + "\r\n");

					// Signals that the receiving procedure is done
					_receiveDone.Set();
				}
				else
				{
					// Not all data received. Get more.
					CommSocket.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}


		// Put message (byte stream) into the socket
		public void SendMessage(Message message)
		{

			if (message == null)
			{
				Console.WriteLine("The message to be sent is empty!");
				return;
			}

			// ReSharper disable once SuggestVarOrType_BuiltInTypes
			string data = JMessage.Serialize(JMessage.FromValue(message));
			data += "<EOF>";

			// Convert the string data to byte data using ASCII encoding.
			var byteData = Encoding.ASCII.GetBytes(data);
			// Send the data to the remote device.
			//			CommSocket.Send(byteData);

			_sendDone.Reset();

			CommSocket.BeginSend(byteData, 0, byteData.Length, 0,
				new AsyncCallback(SendCallback), CommSocket);

			Console.WriteLine("Server sent message to client: {0}", message);
			WindowsManager.Af.AddLog("\tServer sent message to client:\r\n" + message + "\r\n");

			_sendDone.WaitOne();
		}

		private void SendCallback(IAsyncResult ar)
		{
			try
			{
				// Retrieve the socket from the state object.  
				Socket handler = (Socket)ar.AsyncState;

				// Complete sending the data to the remote device.  
				int bytesSent = handler.EndSend(ar);
				Console.WriteLine("Sent {0} bytes to client.", bytesSent);

				_sendDone.Set();

			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		//Put the server to an end
		public void StopServer()
		{
			_everythingDone = true;
			if (ServerMode == ServerMode.NotTreatClient)
			{
				_waitSocket.Close();
				_connectDone.Set();
			}
			else
			{
				// Stop the sending and receiving threads
				CommSocket.Shutdown(SocketShutdown.Both);
				CommSocket.Close();
			}
		}

		public abstract void ManageClient();
		public abstract object Clone();
	}
}