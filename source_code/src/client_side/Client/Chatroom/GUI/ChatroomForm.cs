using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chatroom.Client;
using System.Net;
using Protocol;
using System.Threading;

namespace Chatroom.GUI
{
	public partial class ChatroomForm : Form
	{
		private ClientChatroom _cc;
		private string _topic;
		private string _chatterAlias;

		public ChatroomForm()
		{
			InitializeComponent();
			_topic = ClientManager.SelectedTopic;
			_chatterAlias = ClientManager.Chatter.Alias;

			this.Text = "At " + _chatterAlias + "'s";

			_cc = ClientManager.Cc;

			// Send message to server to join the topic
			// Let the "ConcreteChatroom" inside the "ServerChatroom" object add it to its "Participants" property
			var joinMessage = new Protocol.Message
			{
				Header = HeaderType.JOINCR
			};
			joinMessage.Arguments.AddLast(ClientManager.Chatter.Alias);

			_cc.SendMessage(joinMessage);

			// Start the thread in the end
			new Thread(Operation).Start();
		}

		private void Operation()
		{
			// Reaction to replies from server side
			while (true)
			{
				var message = _cc.GetMessage();
				switch(message.Header)
				{
					case HeaderType.RECV_MSG:
						Console.WriteLine("Received a message from server");
						string msg = message.Arguments.ElementAt(0);
						string alias = message.Arguments.ElementAt(1);
						string msgToAppend = ShowMessage(msg, alias);
						//chatroomTextBox.AppendText(msgToAppend);
						AddText(msgToAppend);
						break;
					default:
						throw new Exception("Not a good reply");
				}
			}
		}
		delegate void coupon(string text);
		private void AddText(string text)
		{
			if (this.chatroomTextBox.InvokeRequired)
			{
				coupon d = new coupon(AddText);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.chatroomTextBox.AppendText(text);
			}
		}

		private string ShowMessage(string message, string alias)
		{
			return "(chez " + ClientManager.Chatter.Alias + ")"
				+ " : " + alias + " $> " + message + "\n";
		}

		private void ChatroomForm_Load(object sender, EventArgs e)
		{

		}

		private void chatroomTextBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void postButton_Click(object sender, EventArgs e)
		{
			// Set cursor to pending icon
			this.Cursor = Cursors.WaitCursor;

			var msg = new Protocol.Message
			{
				Header = HeaderType.POST
			};
			msg.Arguments.AddLast(postTextBox.Text);


			// Send post message to server
			_cc.SendMessage(msg);

			// Receive message from server
			var reply = _cc.GetMessage();

			postTextBox.Text = String.Empty;

			// Reset cursor to default icon
			this.Cursor = Cursors.Default;
		}

		private void postTextBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void quitButton_Click(object sender, EventArgs e) => System.Environment.Exit(0);

		private void logOutButton_Click(object sender, EventArgs e)
		{
			WindowsManager.ShowHideForm(this, false);
			WindowsManager.ShowHideForm(WindowsManager.Af, true);
		}

		private void OnQuit()
		{

		}
	}
}
