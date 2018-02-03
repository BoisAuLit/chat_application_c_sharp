namespace Chatroom.Authentification
{
	public class UserExistsException : AuthentificationException
	{
		public UserExistsException(string login) : base(login)
		{
			
		}

		public override string ToString()
		{
			return "User " + Login + " exists: " + base.ToString();
		}
	}
}