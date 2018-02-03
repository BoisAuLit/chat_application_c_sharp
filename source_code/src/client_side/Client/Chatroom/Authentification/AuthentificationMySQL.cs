using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security;
using MySql.Data.MySqlClient;
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Chatroom.Authentification
{
	public class AuthentificationMySql : IAuthentificationManager
	{
		private Dictionary<string, User> _users;
		
		private readonly MySqlConnection _sqlConnection;

		public AuthentificationMySql()
		{
			_users = new Dictionary<string, User>();
			var mainconn = ConfigurationManager.ConnectionStrings["abcconnection"].ConnectionString;
			_sqlConnection = new MySqlConnection(mainconn);
			_sqlConnection.Open();
			
			var comm = new MySqlCommand("SELECT * FROM user ");
			{
				var da = new MySqlDataAdapter();
				comm.Connection = _sqlConnection;
				da.SelectCommand = comm;
				var dt = new DataTable();
				{
					da.Fill(dt);
				}
				if (dt.Rows.Count == 0) {
					Console.WriteLine("the table is empty");
					return;
				}
				foreach (DataRow dataRow in dt.Rows)
				{
					var login = dataRow["login"] as string;
					var password = dataRow["password"] as string;
					var securePassword = new NetworkCredential("", password).SecurePassword;
					var user = new User(login, securePassword);
					if (login != null) _users.Add(login, user);
					else throw new Exception("Login is null when loading from database!");
				}
			}
		}
		
		public void AddUser(string login, SecureString securePassword)
		{
			if (_users.ContainsKey(login))
				throw new UserExistsException(login);
			_users.Add(login, new User(login, securePassword));
			try
			{
				var pass = new NetworkCredential("", securePassword).Password;
				var sql = "INSERT INTO user(login, password) VALUES('" + login + "', '" + pass + "')";
				var cmd = new MySqlCommand(sql, _sqlConnection);
				cmd.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.ToString());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		public void RemoveUser(string login)
		{
			if(!_users.ContainsKey(login))
				throw new UserUnknownException(login);
			_users.Remove(login);
			try
			{
				var sql = "DELETE FROM user WHERE login='" + login + "'";
				var cmd = new MySqlCommand(sql, _sqlConnection);
				cmd.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.ToString());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
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
			// nothing to do here
		}

		public void Save(string path)
		{
			// nothing to do here
		}

		public void Close()
		{
			_sqlConnection.Close();
		}
	}
}