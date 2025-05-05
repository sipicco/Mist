using Mist.Backend.DTOs;

namespace Mist.Backend.Models
{
	public class GetUsersResponse
	{
		public GetUsersResponse(IEnumerable<GetUserDto> userDtos)
		{
			UserDtos = userDtos;
			TotalCount = userDtos.Count();
		}

		public IEnumerable<GetUserDto> UserDtos { get; set; }
		public int TotalCount { get; set; }
	}
}
