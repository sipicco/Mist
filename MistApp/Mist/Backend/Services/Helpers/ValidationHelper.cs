using Mist.Backend.Repositories.Interfaces;

namespace Mist.Backend.Services.Helpers
{
	public static class ValidationHelper
	{
		public static async Task CheckIfUserExistsElseThrow(Guid userId, IUserRepository userRepo)
		{
			if( await userRepo.GetSingleUserAsync(userId) == null)
			{
				throw new KeyNotFoundException($"UserId - {userId} not found!");
			}			
		}
	}
}
