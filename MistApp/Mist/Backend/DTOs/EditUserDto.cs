namespace Mist.Backend.DTOs
{
	public class EditUserDto
	{
		public EditUserDto(string username, string email)
		{
			Username = username;
			Email = email;
		}

		public string Username { get; set; }
		public string Email { get; set; }
	}
}
