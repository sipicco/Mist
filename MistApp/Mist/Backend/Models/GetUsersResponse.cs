using Mist.Backend.DTOs;

namespace Mist.Backend.Models
{
	public class GetUsersResponse
	{
		public IEnumerable<GetUserDto> UserDtos { get; set; }
		public int TotalCount { get; set; }
	}
}
