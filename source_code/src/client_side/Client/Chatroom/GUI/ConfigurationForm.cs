using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Chatroom.Client;

namespace Chatroom.GUI
{
	public partial class ConfigurationForm : Form
	{
		public ConfigurationForm()
		{
			InitializeComponent();
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			ipTextBox.Text = "";
			portTextBox.Text = "";
		}

		private void exitButton_Click(object sender, EventArgs e)
		{
			WindowsManager.Quit();
		}

		private void confirmButton_Click(object sender, EventArgs e)
		{
			// Retrieve authentification server Ip address
			if (IPAddress.TryParse(ipTextBox.Text, out IPAddress ip))
				ClientManager.ServerIP = ip;
			else { 
				MessageBox.Show("Can't parse this ip, something must be wrong");
				return;
			}

			// Retrieve authentification server port number
			if (Int32.TryParse(portTextBox.Text, out int port))
				ClientManager.AuthentificationServerPort = port;
			else { 
				MessageBox.Show("Can't parse this port number, something must be wrong");
				return;
			}

			// Create new authentification client
			AuthentificationClient ac = new AuthentificationClient();
			ac.SetServer(new IPEndPoint(ClientManager.ServerIP, ClientManager.AuthentificationServerPort));
			ac.Connect();
			ClientManager.Ac = ac;

			var form = new AuthentificationForm();
			WindowsManager.Af = form;

			WindowsManager.ShowHideForm(this, false);
			WindowsManager.ShowHideForm(form, true);

		}

		private void ConfigurationForm_Load(object sender, EventArgs e)
		{

		}
	}
}
