namespace Chatroom.Authentification
{
	public class WrongPasswordException : AuthentificationException
	{
		public WrongPasswordException(string login) : base(login)
		{
			
		}
		
		public override string ToString()
		{
			return "Password for user " + Login + " incorrect: " + base.ToString();
		}
	}
}