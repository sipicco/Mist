namespace Mist.Backend.Models
{
	public class LoginUserResponse
	{
		public LoginUserResponse(string accessToken, string refreshToken, int expiresIn)
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
			ExpiresIn = expiresIn;
		}

		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public int ExpiresIn { get; set; } // in seconds
	}
}
