namespace Mist.Backend.Exceptions
{
	public class EmailAlreadyExistsException : Exception
	{
		public EmailAlreadyExistsException(string email)
			: base($"An account with the email '{email}' already exists.") { }
	}
}
