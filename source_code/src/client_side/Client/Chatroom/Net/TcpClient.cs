using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Protocol;

// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Chatroom.Net
{
    public abstract class TcpClient : IMessageConnection
    {
        protected Socket CommSocket;

        // Thread signals
        protected ManualResetEvent ConnectDone = new ManualResetEvent(false);
        protected ManualResetEvent ReceiveDone = new ManualResetEvent(false);
        protected ManualResetEvent SendDone = new ManualResetEvent(false);

        protected Message MessageReceived;

		public IPEndPoint RemoteEp;
		public IPEndPoint LocalEp;

        // Set the remote endpoint server information for this client
        public void SetServer(IPEndPoint remoteEp)
        {
			RemoteEp = remoteEp;
            // Set socket type
            CommSocket = new Socket(
				AddressFamily.InterNetwork, 
				SocketType.Stream, 
				ProtocolType.Tcp);
        }

        // Connect to remote server and run
        public void Connect()
        {
			try {
				// Connect to remote server
				CommSocket.BeginConnect(
					RemoteEp, 
					ConnectCallback, 
					null);
				// Wait until connection is done to continue
				ConnectDone.WaitOne();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

        private void ConnectCallback(IAsyncResult ar)
        {
			try { 
				// Complete the connection.
				CommSocket.EndConnect(ar);
				LocalEp = (IPEndPoint)CommSocket.LocalEndPoint;
				Console.WriteLine("Client connected to server at " + CommSocket.RemoteEndPoint);
				// Signal that the connection has been made.
				ConnectDone.Set();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}

		}

        //Get message from chatroom
        public Message GetMessage()
        {
			try { 
				ReceiveDone.Reset();
				var state = new StateObject();
				CommSocket.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);

				// Wait until all the comlete message is received
				ReceiveDone.WaitOne();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			return MessageReceived;
		}

        private void ReceiveCallback(IAsyncResult ar)
        {
			try { 
				// Retrieve the state object and the client socket 
				// from the asynchronous state object.
				var state = (StateObject)ar.AsyncState;
				// Read data from the remote device.
				var bytesRead = CommSocket.EndReceive(ar);

				if (bytesRead <= 0) return;

				// There  might be more data, so store the data received so far.
				state.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

				// Check for end-of-file tag. If it is not there, more data.
				var content = state.Sb.ToString();
				if (content.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
				{
					// ReSharper disable once SuggestVarOrType_SimpleTypes
					JMessage jm = JMessage.Deserialize(content.Replace("<EOF>", ""));
					MessageReceived = jm.Value.ToObject<Message>();

					// *************************************************************************************
					// Debug information, to be deleted
					// Display the message received
					Console.WriteLine("\nServer received message from client: " + MessageReceived + "\n");
					// Signals that the receiving procedure is done
					// *************************************************************************************
					ReceiveDone.Set();
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
            SendDone.Reset();
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

            CommSocket.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), CommSocket);
            // Wait until the message is well sent
            SendDone.WaitOne();
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                SendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Stop()
        {
			
            // Shutdown the socket so that it cannot send data to socket
            // or receive data from socket anymore
            CommSocket.Shutdown(SocketShutdown.Both);
            // Release resources relevant to the socket
            CommSocket.Close();
        }
    }
}