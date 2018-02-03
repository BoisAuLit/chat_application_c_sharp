namespace Chatroom.Authentification
{
	public class UserUnknownException : AuthentificationException
	{
		public UserUnknownException(string login) : base(login)
		{
			
		}
		
		public override string ToString()
		{
			return "User " + Login + " unknown: " + base.ToString();
		}
	}
}