using System;
using System.Linq;
using System.Windows.Forms;
using Chatroom.Client;
using Protocol;
using System.Threading;
using System.Net;

namespace Chatroom.GUI
{
	public partial class ChoosingTopicForm : Form
	{
		private ClientTopicManager _ctm;

		public ChoosingTopicForm()
		{
			InitializeComponent();

			this.chooseTopicLabel.Text += ", " + ClientManager.Chatter.Alias;
			_ctm = ClientManager.Ctm;

			// Send message to server requesting to show all the topics

			var message = new Protocol.Message
			{
				Header = HeaderType.LIST_TOPICS
			};
			message.Arguments.AddLast(ClientManager.Chatter.Alias);

			_ctm.SendMessage(message);
			
			var reply = _ctm.GetMessage();

			if (reply.Header == HeaderType.LIST_TOPICS_REPLY)
			{
				if (reply.Arguments.Count == 0)
					Console.WriteLine("No topics available");
				else
					foreach (var topic in reply.Arguments)
						topicListBox.Items.Add(topic);
			}
			else
				throw new Exception("It is not a good reply!");

			new Thread(Operation).Start();
		}

		// Things to be done upon receiving message from server
		private void Operation()
		{
			while (true)
			{
				var reply = _ctm.GetMessage();
				Console.WriteLine("\tMessage received from server \n" + reply);
				switch (reply.Header)
				{
					case HeaderType.NEW_TOPIC_CREATED:
						string newTopic = reply.Arguments.ElementAt(0);
						AddTopic(newTopic);
						ShowMessage("New topic created: " + newTopic);
						break;
					case HeaderType.CREATE_TOPIC_REPLY:
						if (reply.Arguments.ElementAt(0) == "success")
						{
							Console.WriteLine("Topic created with success");
						}
						else if (reply.Arguments.ElementAt(0) == "failure")
						{
							Console.WriteLine("Topic created with failure");
							Console.WriteLine("The reason is: " + _ctm.FailureMessage);
							ShowMessage("Topic  created with failure: " + _ctm.FailureMessage);
						}
						else
							throw new Exception("First argument not known");
						break;
					case HeaderType.JOIN_TOPIC_REPLY:
						var status = reply.Arguments.ElementAt(0);
						var topicToJoin = reply.Arguments.ElementAt(1);
						ClientManager.SelectedTopic = topicToJoin;
						// Successfully joined the relevant topic room
						if (status == "success")
						{
							//var chatroomPort = reply.Arguments.ElementAt(1);
							if (Int32.TryParse(reply.Arguments.ElementAt(1), out int chatroomPort))
							{
								ClientManager.ServerChatroomPort = chatroomPort;
								Console.WriteLine("The relevant server chatroom port is: {0}", chatroomPort);
								OnJoinTopicOkay();
							}
							else
								throw new Exception("Cannot convert the string to integer!");

						}
						else
						{
							Console.WriteLine("Join topic failure");
							Console.WriteLine("Failure message: " + reply.Arguments.ElementAt(1));
						}

						// Reset cursor style
						break;
					default:
						throw new Exception("Not a good reply");
				}
			}
		}

		private delegate void RefreshText(string text);
		private void AddTopic(string text)
		{
			if (this.topicListBox.InvokeRequired)
				this.Invoke(new RefreshText(AddTopic), new object[] { text });
			else
				this.topicListBox.Items.Add(text);
		}
		private void ShowMessage(string text)
		{
			if (this.topicListBox.InvokeRequired)
				this.Invoke(new RefreshText(ShowMessage), new object[] { text });
			else
				this.messageTextBox.Text = text;
		}


		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void ChoosingTopicForm_Load(object sender, EventArgs e)
		{

		}

		// Manage create topic button
		private void button1_Click(object sender, EventArgs e)
		{
			// Get the topic to be created
			string topic = createTopicTextBox.Text;

			// Check that if the topic to be added is null or whitespcae or empty
			if (String.IsNullOrEmpty(topic) || String.IsNullOrWhiteSpace(topic))
			{
				Console.WriteLine("Topic to be created is empty!");
				return;
			}
			else if (topicListBox.Items.Contains(topic))
			{
				Console.WriteLine("Topic already exist!");
				return;
			}
			var message = new Protocol.Message
			{
				Header = HeaderType.CREATE_TOPIC
			};
			// Send the create topic request to server
			message.Arguments.AddLast(topic);
			_ctm.SendMessage(message);

			// $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
			Console.WriteLine("Message sent: " + message);
			// $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$


		}

		private void exitButton_Click(object sender, EventArgs e)
		{

			var exitMessage = new Protocol.Message
			{
				Header = HeaderType.EXIT
			};

			_ctm.SendMessage(exitMessage);


			System.Environment.Exit(0);

			WindowsManager.Quit();
		}

		private void createTopicTextBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void joinTopicButton_Click(object sender, EventArgs e)
		{
			// If no topic is selected, then warn the user about it
			if (topicListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an item first");
				return;
			}

			// Join the selected chat room
			var selectedTopic = topicListBox.GetItemText(topicListBox.SelectedItem);
			var joinMessage = new Protocol.Message
			{
				Header = HeaderType.JOIN_TOPIC
			};
			joinMessage.Arguments.AddLast(selectedTopic);

			_ctm.SendMessage(joinMessage);
		}

		// Invoked after successfully joinint a chat room
		private void OnJoinTopicOkay()
		{
			// Create new ClientChatroom
			ClientChatroom cc = new ClientChatroom();
			cc.SetServer(new IPEndPoint(
				ClientManager.ServerIP,
				ClientManager.ServerChatroomPort));
			cc.Connect();
			ClientManager.Cc = cc;

			// Create new ChatroomForm
			var form = new ChatroomForm();
			WindowsManager.Cf = form;


			// Hide the current window
			WindowsManager.ShowHideForm(this, false);
			// Show the next window
			WindowsManager.ShowHideForm(form, true);
			Application.Run();
		}

		private void messageTextBox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
