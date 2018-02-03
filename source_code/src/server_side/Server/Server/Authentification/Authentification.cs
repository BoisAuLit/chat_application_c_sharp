using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;

namespace Chatroom.Authentification
{
	[Serializable]
	public class Authentification : IAuthentificationManager
	{
		private Dictionary<string, User> _users;

		public Authentification()
		{
			_users = new Dictionary<string, User>();
		}

		public void AddUser(string login, SecureString securePassword)
		{
			if (_users.ContainsKey(login))
				throw new UserExistsException(login);
			_users.Add(login, new User(login, securePassword));
		}

		public void RemoveUser(string login)
		{
			if(!_users.ContainsKey(login))
				throw new UserUnknownException(login);
			_users.Remove(login);
		}

		public void Authentify(string login, SecureString password)
		{
			if(!_users.ContainsKey(login))
				throw new UserUnknownException(login);
			
			var user = _users[login];
			if (user.Authentify(password))
				Console.WriteLine(login + " Authengification Okay!");
			else
				throw new WrongPasswordException(login);
		}

		public void Load(string path)
		{
			try
			{
				string line;
				var file = new StreamReader(path);
				while ((line = file.ReadLine()) != null)
				{
					var reader = new StringReader(line);
					var words = reader.ReadToEnd().Split(' ');
					var login = words[0];
					var password = new NetworkCredential("", words[1]).SecurePassword;
					var user = new User(login, password);
					_users.Add(login, user);
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		public void Save(string path)
		{
			try
			{
				var nbUsers = _users.Count;
				var lines = new string[nbUsers];
				var index = 0;
				foreach (var user in _users.Values)
				{
					lines[index++] = user.ToString();
				}
				File.WriteAllLines(path, lines);
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
			}
		}
	}
}