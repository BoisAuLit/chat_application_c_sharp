using System;
using Chatroom.Authentification;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using System.Threading;
using Chatroom.Chat;
using Chatroom.Server;
using System.Windows.Forms;
using Chatroom.GUI;

namespace Chatroom
{
	internal class Program
	{
		private static void Separate()
		{
			Console.WriteLine("\n*****************************************************************************\n");
		}


		public static void Test1()
		{
			// Test communication utilisateurs
			IChatter bob = new TextChatter("Bob");
			IChatter joe = new TextChatter("Joe");

			ITopicManager gt = new TextTopicManager();

			gt.CreateTopic("java");
			gt.CreateTopic("UML");
			gt.ListTopics();
			gt.CreateTopic("jeux");
			gt.ListTopics();
			IChatroom cr = gt.JoinTopic("jeux");
			cr.Join(bob);
			cr.Post("Je suis seul ou quoi ?", bob);
			cr.Join(joe);
			cr.Post("Tiens, salut Joe !", bob);

			cr.Post("Toi aussi tu chat sur les forums " +
					"de jeux pendant les TP, Bob?", joe);
		}

		public static void Test2()
		{
			//Test gestion utilisateurs

			IAuthentificationManager am = new Authentification.Authentification();

			try
			{
				SecureString password = new NetworkCredential("", "123").SecurePassword;
				am.AddUser("bob", password);
				Console.WriteLine("Bob has been added!");
				am.RemoveUser("bob");
				Console.WriteLine("Bob has been removed!");
				am.RemoveUser("bob");
				Console.WriteLine("Bob has been removes twice !");
			}
			catch (UserUnknownException e)
			{
				Console.WriteLine(e.Login + " : user unknown (unable to remove)!");
			}
			catch (UserExistsException e)
			{
				Console.WriteLine(e.Login + " has already been added!");
			}

			Separate();
			// Test authentification
			try
			{
				SecureString password1 = new NetworkCredential("", "123").SecurePassword;
				am.AddUser("bob", password1);
				Console.WriteLine("Bob has been added !");
				SecureString password2 = new NetworkCredential("", "123").SecurePassword;
				am.Authentify("bob", password2);
				Console.WriteLine("Authentification OK !");
				SecureString password3 = new NetworkCredential("", "456").SecurePassword;
				am.Authentify("bob", password3);
				Console.WriteLine("Invalid password !");
			}
			catch (WrongPasswordException e)
			{
				Console.WriteLine(e.Login + " has provided an invalid password!");
			}
			catch (UserExistsException e)
			{
				Console.WriteLine(e.Login + " has already been added.");
			}
			catch (UserUnknownException e)
			{
				Console.WriteLine(e.Login + " : user unknown (unable to remove)!");
			}

			Separate();
			// Test persistence
			try
			{
				string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
					@"../../Data/Users.txt");
				am.Save(path);
				IAuthentificationManager am1 = new Authentification.Authentification();
				am1.Load(path);
				SecureString password = new NetworkCredential("", "123").SecurePassword;
				am1.Authentify("bob", password);
				Console.WriteLine("Loading complete !");
			}
			catch (UserUnknownException e)
			{
				Console.WriteLine(e.Login + " is unknown ! Error during the saving/loading.");
			}
			catch (WrongPasswordException e)
			{
				Console.WriteLine(e.Login + " has provided an invalid password ! Error during the saving/loading.");
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		public static void Test3()
		{
			IAuthentificationManager am = new AuthentificationMySql();
			// Test gestion utilisateurs
			try
			{
				SecureString password = new NetworkCredential("", "123").SecurePassword;
				am.AddUser("bob", password);
				Console.WriteLine("Bob has been added!");
				am.RemoveUser("bob");
				Console.WriteLine("Bob has been removed!");
				am.RemoveUser("bob");
				Console.WriteLine("Bob has been removes twice !");
			}
			catch (UserUnknownException e)
			{
				Console.WriteLine(e.Login + " : user unknown (unable to remove)!");
			}
			catch (UserExistsException e)
			{
				Console.WriteLine(e.Login + " has already been added!");
			}

			Separate();
			// Test authentification
			try
			{
				SecureString password1 = new NetworkCredential("", "123").SecurePassword;
				am.AddUser("bob", password1);
				Console.WriteLine("Bob has been added !");
				SecureString password2 = new NetworkCredential("", "123").SecurePassword;
				am.Authentify("bob", password2);
				Console.WriteLine("Authentification OK !");
				SecureString password3 = new NetworkCredential("", "456").SecurePassword;
				am.Authentify("bob", password3);
				Console.WriteLine("Invalid password !");
			}
			catch (WrongPasswordException e)
			{
				Console.WriteLine(e.Login + " has provided an invalid password!");
			}
			catch (UserExistsException e)
			{
				Console.WriteLine(e.Login + " has already been added.");
			}
			catch (UserUnknownException e)
			{
				Console.WriteLine(e.Login + " : user unknown (unable to remove)!");
			}

			((AuthentificationMySql)am).Close();
			Separate();
			// Test persistence
			try
			{
				IAuthentificationManager am1 = new AuthentificationMySql();
				SecureString password = new NetworkCredential("", "123").SecurePassword;
				am1.Authentify("bob", password);
				((AuthentificationMySql)am1).Close();
			}
			catch (UserUnknownException e)
			{
				Console.WriteLine(e.Login + " is unknown ! Error during the saving/loading.");
			}
			catch (WrongPasswordException e)
			{
				Console.WriteLine(e.Login + " has provided an invalid password ! Error during the saving/loading.");
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		[STAThread]
		public static void Main(string[] args)
		{

			// Uncomment to test!

			// Test No.1
			// 		test communication utilisateurs
			//			Test1();
			//			Separate();

			// Test No.2
			// 		test -> gestion utilisateurs
			// 		test -> authentification
			// 		test -> persistence
			//			Test2();
			//			Separate();

			// Test No.3
			// 		test base de données
			//			Test3();

			ServerManager.StartServer();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new AdministratorForm());
		}
	}
}