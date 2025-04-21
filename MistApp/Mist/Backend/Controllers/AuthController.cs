using Microsoft.AspNetCore.Mvc;
using Mist.Backend.Models;
using Mist.Backend.Services.Interfaces;


namespace Mist.Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IAuthService _authService;

	public AuthController(IAuthService authService)
	{
		_authService = authService;
	}

	/// <summary>
	/// Log in user with email and password
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	// POST Auth
	[HttpPost("/Login")]
	public async Task<IActionResult> Post([FromQuery] LoginUserRequest request)
	{
		return Ok(await _authService.LoginUserAsync(request));
	}
}
