using Mist.Backend.Entities;
using System.Security.Claims;

namespace Mist.Backend.Services.Interfaces
{
	public interface ITokenService
	{
		string GenerateAccessToken(User user);
		string GenerateRefreshToken();
		ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
	}

}
