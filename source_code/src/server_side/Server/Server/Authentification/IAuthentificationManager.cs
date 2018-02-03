using System.IO;
using System.Security;

namespace Chatroom.Authentification
{
	public interface IAuthentificationManager
	{
		/// <exception cref="UserExistsException"></exception>
		/// <summary>Add a user.</summary>
		/// <param name="login">The login of the user to be added.</param>
		/// <param name="securePassword">The password of the user to be added.</param>
		void AddUser(string login, SecureString securePassword);
		
		/// <exception cref="UserUnknownException"></exception>
		/// <summary>Remove a user.</summary>
		/// <param name="login">Remove a user with the given login.</param>
		void RemoveUser(string login);
		
		/// <exception cref="UserUnknownException"></exception>
		/// <exception cref="WrongPasswordException"></exception>
		/// <summary>Authentify a user.</summary>
		/// <param name="login">Login of the user.</param>
		/// <param name="password">Password of the user.</param>
		void Authentify(string login, SecureString password);
		
		/// <exception cref="IOException"></exception>
		/// <summary>Load authenfification file.</summary>
		/// <param name="path">Load file using the given path.</param>
		void Load(string path);
		
		/// <exception cref="IOException"></exception>
		/// <summary>Save authentificatin file to the give path.</summary>
		/// <param name="path">The paht used to save the file.</param>
		void Save(string path);
	}
}