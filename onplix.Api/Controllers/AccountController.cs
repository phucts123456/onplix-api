using Microsoft.AspNetCore.Mvc;
using onplix.Application.DTOs;
using onplix.Application.Interfaces;

namespace onplix.Api.Controllers
{
	[Route("api/account")]
	[ApiController]
	public class AccountController(IAccountService _accountService) : ControllerBase
	{
		/// <summary>
		/// Register account endpoint
		/// </summary>
		/// <param name="dto"></param>
		/// <returns>Response</returns>
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] AccountRegisterDTO dto)
		{
			var result = await _accountService.RegisterAsync(dto);
			if (result.StatusCode == 200 || result.StatusCode == 201)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Login account endpoint
		/// </summary>
		/// <param name="dto"></param>
		/// <returns>Response</returns>
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] AccountLoginDTO dto)
		{
			var result = await _accountService.LoginAsync(dto);
			if (result.StatusCode == 200 || result.StatusCode == 201)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
