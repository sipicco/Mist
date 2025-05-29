using Mist.Backend.Entities;
using System.Security.Claims;

namespace Mist.Backend.Services.Interfaces
{
	public interface ITokenService
	{
		string GenerateAccessToken(User user);
		string GenerateRefreshToken();

		/// <summary>
		/// Extracts the <see cref="ClaimsPrincipal"/> from a JWT access token, even if the token is expired.
		/// </summary>
		/// <param name="token">The expired JWT access token.</param>
		/// <returns>
		/// The <see cref="ClaimsPrincipal"/> representing the user claims, 
		/// or <c>null</c> if the token is invalid or does not use the expected algorithm.
		/// </returns>
		ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
	}

}
