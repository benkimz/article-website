using System.Text.RegularExpressions;

namespace Applantus.Tingum.WebApp.Services
{
	public class DataValidation
	{
		public static bool ValidateEmail(string email)
		{
			string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(email);
		}
	}
}
