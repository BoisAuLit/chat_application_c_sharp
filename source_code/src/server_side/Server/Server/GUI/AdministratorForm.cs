using System;
using System.Windows.Forms;
using Chatroom.Server;

namespace Chatroom.GUI
{
	public partial class AdministratorForm : Form
	{
		
		public AdministratorForm()
		{
			InitializeComponent();
			WindowsManager.Af = this;

			foreach (var alias in Server.AuthentificationServer.Users.Keys)
				this.AddUser(alias);
		}

		//*****************************************************
		delegate void AddText(string text);
		public void AddUser(string text)
		{
			if (this.activeChatroomsListBox.InvokeRequired)
			{
				AddText d = new AddText(AddUser);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.usersListBox.Items.Add(text);
			}
		}
		public void AddChatroom(string text)
		{
			if (this.activeChatroomsListBox.InvokeRequired)
			{
				AddText d = new AddText(AddChatroom);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.activeChatroomsListBox.Items.Add(text);
			}
		}
		public void AddClient(string text)
		{
			if (this.connectedClientListBox.InvokeRequired)
			{
				AddText d = new AddText(AddClient);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.connectedClientListBox.Items.Add(text);
			}
		}
		public void AddLog(string text)
		{
			if (this.logTextBox.InvokeRequired)
			{
				AddText d = new AddText(AddLog);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.logTextBox.AppendText(text);
			}
		}
		//*****************************************************

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void AdministratorForm_Load(object sender, EventArgs e)
		{

		}

		private void exitButton_Click(object sender, EventArgs e)
		{
			ServerManager.StopServer();
		}
	}
}
