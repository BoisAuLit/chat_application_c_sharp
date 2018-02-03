using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chatroom.Authentification;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using Chatroom.Chat;
using System.Configuration;
using System.Threading;
using Chatroom.Net;
using Chatroom.GUI;
using System.Net.Sockets;
using System.Text;

namespace Chatroom
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			new Thread(Test).Start();

			//for (int i = 0; i < 2; i++)
			//{
			//	new Thread(Test).Start();
			//}
		}

		private static void Test()
		{
			Application.Run(new ConfigurationForm());
		}
	}
}
