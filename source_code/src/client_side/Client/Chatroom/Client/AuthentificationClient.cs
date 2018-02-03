using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatroom.Net;
using Protocol;
using System.Threading;
using Chatroom.GUI;

namespace Chatroom.Client
{
    class AuthentificationClient : TcpClient
    {
        public string FailureMessage;
		public int ServerTopicManagerPort;

		public bool Validate(string userName, string password)
        {
            var msg = new Message
            {
                Header = HeaderType.AUTHENTIFICATION_REQUEST
            };
            msg.Arguments.AddLast(userName);
            msg.Arguments.AddLast(password);

            SendMessage(msg);

            var message = GetMessage();

            // Get the response
            if (message.Header == HeaderType.AHTHENTIFICATION_REPLY)
            {
                var status = message.Arguments.ElementAt(0);
                if (status == "success")
                {
					var portString = message.Arguments.ElementAt(1);
					
					if (Int32.TryParse(portString, out int portNumber)) {
						ServerTopicManagerPort = portNumber;
						Console.WriteLine("The received port number is: " + portNumber);
					}
					else
						throw new Exception("Port format not good!");
                    return true;
                }
                else if (status == "failure")
                {
                    FailureMessage = message.Arguments.ElementAt(1);
                    return false;
                }
                else
                {
                    throw new Exception("status message not good! in AuthentificationClient class");
                }
            }
            else
            {
                throw new Exception("Header type not right in AuthentificationClient class!");
            }
        }

    }
}
