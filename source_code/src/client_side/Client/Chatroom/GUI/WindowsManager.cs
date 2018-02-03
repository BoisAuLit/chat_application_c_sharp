using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatroom.GUI
{
	class WindowsManager
	{
		public static AuthentificationForm Af { get; set; }
		public static ChoosingTopicForm Ctf { get; set; }
		public static ChatroomForm Cf { get; set; }
		public static ConfigurationForm Cff { get; set; }



		// Show hide form in a thread-safe way
		public static void ShowHideForm(Form form, bool show /* otherwise hide */)
		{
			if (form.InvokeRequired)
			{
				form.Invoke(new Action<Form, bool>((formInstance, isShow) =>
				{
					if (isShow)
						formInstance.Show();
					else
						formInstance.Hide();
				}), form, show);
			}
			else
			{
				if (show)
					form.Show();
				else
					form.Hide();
			} //if
		}

		public static void Quit()
		{
			if (System.Windows.Forms.Application.MessageLoop)
			{
				System.Windows.Forms.Application.Exit();
			}
			else
			{
				System.Environment.Exit(1);
			}
		}
	}
}
