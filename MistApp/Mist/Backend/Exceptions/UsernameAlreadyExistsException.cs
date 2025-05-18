namespace Mist.Backend.Exceptions
{
	public class UsernameAlreadyExistsException : Exception
	{
		public UsernameAlreadyExistsException(string username)
			: base($"An account with username: {username} already exists.") { }
		
	}
}
