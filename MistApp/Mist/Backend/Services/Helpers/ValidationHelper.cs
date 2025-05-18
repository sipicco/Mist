using Mist.Backend.Exceptions;
using Mist.Backend.Models;
using Mist.Backend.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using BadHttpRequestException = Microsoft.AspNetCore.Http.BadHttpRequestException;

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

		internal static async Task ValidateCreateUserRequest(CreateUserRequest request, IUserRepository userRepository)
		{
			await CheckIfUsernameIsAvailableElseThrow(request.Username, userRepository);
			CheckIfEmailIsValidElseThrow(request.Email);
			await CheckIfEmailAlreadyExistsElseThrow(request.Email, userRepository);
		}

		private static async Task CheckIfEmailAlreadyExistsElseThrow(string email, IUserRepository userRepository)
		{
			if (await userRepository.IsEmailExisting(email))
			{
				throw new EmailAlreadyExistsException(email);
			}
		}

		private static void CheckIfEmailIsValidElseThrow(string email)
		{
			var emailAttr = new EmailAddressAttribute();
			if (!emailAttr.IsValid(email))
			{
				throw new BadHttpRequestException("Invalid email format");
			}
		}


		private static async Task CheckIfUsernameIsAvailableElseThrow(string username, IUserRepository userRepository)
		{
			if(await userRepository.IsUsernameExisting(username))
			{
				throw new UsernameAlreadyExistsException(username);
			}
		}
	}
}
