using Chatroom.Client;
using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chatroom.Chat;
using Chatroom.Net;
using Protocol;

namespace Chatroom.GUI
{
    public partial class AuthentificationForm : Form
    {
        private AuthentificationClient _ac;

        public AuthentificationForm()
        {
			this._ac = ClientManager.Ac;

			InitializeComponent();
			this.AcceptButton = confirmButton;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void userNameTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.userNameTextBox.Text = "";
            this.passwordTextBox.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

			// Send exit message to the authentificaiton server so that the server could
			// shut down and close to free the relevant resources
			var exitMessage = new Protocol.Message
			{
				Header = HeaderType.EXIT
			};
			_ac.SendMessage(exitMessage);
			_ac.Stop();
			//Application.Exit();
			WindowsManager.Quit();
        }

        private void AuthentificationForm_Load(object sender, EventArgs e)
        {
				
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
			this.ShowMessage("Waiting for authentification reply...");

            // Checking syntax errors for user name & password
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("password empty or withespace or null");
                //MessageBox.Show("Password empty or withespace or null!", "Error message", 
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password empty or whitespace or null");
                //MessageBox.Show("Password empty or withespace or null!", "Error message",
                //     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Authentification
            if (_ac.Validate(userName, password))
            {
                Console.WriteLine("Authentification okay!");
				this.ShowMessage("Authentification okay!");
                this.Cursor = Cursors.Default;
				ClientManager.ServerTopicManagerPort = _ac.ServerTopicManagerPort;
				OnAuthentificationOkay();
                return;
            }
            else
            {
                Console.WriteLine("Authentification failure: " + _ac.FailureMessage);
				this.ShowMessage(_ac.FailureMessage);
                this.Cursor = Cursors.Default;
                return;
            }

        }

		delegate void coupon(string text);
		private void ShowMessage(string text)
		{
			if (this.messageTextBox.InvokeRequired)
			{
				coupon d = new coupon(ShowMessage);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				//this.errorTextBox.AppendText(text);
				this.messageTextBox.Text = text;
			}
		}

		// Things to be done when authentification is okay
		private void OnAuthentificationOkay()
		{

			// Create a chatter object associated with the current chatter
			ClientManager.Chatter = new TextChatter(userNameTextBox.Text);

			// Create new ClientTopicManager
			var ctm = new ClientTopicManager();
			ctm.SetServer(new IPEndPoint(ClientManager.ServerIP, ClientManager.ServerTopicManagerPort));
			ctm.Connect();
			ClientManager.Ctm = ctm;

			// Create new ChoosingTopicForm
			var form = new ChoosingTopicForm();
			WindowsManager.Ctf = form;

			// Hide the current windows
			WindowsManager.ShowHideForm(this, false);

			// Show next window
			WindowsManager.ShowHideForm(form, true);
		}

		private void errorTextBox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
