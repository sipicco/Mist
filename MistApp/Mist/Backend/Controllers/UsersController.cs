using Microsoft.AspNetCore.Mvc;
using Mist.Backend.Models;
using Mist.Backend.Services.Interfaces;


namespace Mist.Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly IUserService _userService;

	public UsersController(IUserService userService)
	{
		_userService = userService;
	}

	/// <summary>
	/// Retieves all the users from db
	/// </summary>
	/// <returns></returns>
	// GET Users
	[HttpGet]
	public async Task<IActionResult> GetUsers()
	{
		return Ok(await _userService.GetAllUsersAsync());
	}

	/// <summary>
	/// Retrieves a specific user from the db
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	// GET Users/{id}
	[HttpGet("{id}")]
	public string Get(int id)
	{
		return "value";
	}

	/// <summary>
	/// Add a new user in the db
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	// POST Users
	[Route("")]
	[HttpPost]
	public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
	{
		return Ok(await _userService.RegisterUserAsync(request));
	}
}
