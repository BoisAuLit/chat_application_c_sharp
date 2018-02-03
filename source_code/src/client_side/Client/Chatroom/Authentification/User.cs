using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;

namespace Chatroom.Authentification
{
	[Serializable]
	public class User : IComparable
	{
		private readonly string _login;
		
		private readonly SecureString _password;

		public User(string login, SecureString password)
		{
			_login = login;
			_password = password;
		}
		
		public int CompareTo(object obj)
		{
			var c = (User) obj;
			return string.CompareOrdinal(c._login, _login);
		}

		public bool Authentify(SecureString password)
		{
			return IsEqualTo(_password, password);
		}

		public override string ToString()
		{
			return _login + " " + new NetworkCredential("", _password).Password;
		}
		
		public static bool IsEqualTo(SecureString ss1, SecureString ss2)
		{
			var bstr1 = IntPtr.Zero;
			var bstr2 = IntPtr.Zero;
			try
			{
				bstr1 = Marshal.SecureStringToBSTR(ss1);
				bstr2 = Marshal.SecureStringToBSTR(ss2);
				var length1 = Marshal.ReadInt32(bstr1, -4);
				var length2 = Marshal.ReadInt32(bstr2, -4);
				if (length1 == length2)
				{
					for (var x = 0; x < length1; ++x) 
					{
						var b1 = Marshal.ReadByte(bstr1, x);
						var b2 = Marshal.ReadByte(bstr2, x);
						if (b1 != b2) return false;
					}
				}
				else return false;
				return true;
			}
			finally
			{
				if (bstr2 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr2);
				if (bstr1 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr1);
			}
		}
	}
}