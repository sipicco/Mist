namespace Mist.Backend.Models
{
	public class JwtSettings
	{
		public string SecretKey { get; set; } = null!;
		public string Issuer { get; set; } = null!;
		public string Audience { get; set; } = null!;
		public int TokenExpiryMinutes { get; set; }
		public int RefreshTokenExpiryDays { get; set; }
	}
}
