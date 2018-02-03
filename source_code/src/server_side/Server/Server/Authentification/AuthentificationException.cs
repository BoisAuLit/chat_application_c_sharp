using System;

namespace Chatroom.Authentification
{
	public class AuthentificationException : Exception
	{
		public string Login { get; set; }

		public AuthentificationException(string login)
		{
			Login = login;
		}
	}
}