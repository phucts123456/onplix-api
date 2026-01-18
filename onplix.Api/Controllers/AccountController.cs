using MediatR;
using Microsoft.AspNetCore.Mvc;
using onplix.Application.DTOs;
using onplix.Application.Queries.Account;

namespace onplix.Api.Controllers
{
	[Route("api/account")]
	[ApiController]
	public class AccountController(Mediator _mediator) : ControllerBase
	{
		/// <summary>
		/// Register account endpoint
		/// </summary>
		/// <param name="dto"></param>
		/// <returns>Response</returns>
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] AccountRegisterDTO dto)
		{
			var result = await _mediator.Send(new RegisterAccountQuery(dto));
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
			var result = await _mediator.Send(new LoginAccountQuery(dto));
			if (result.StatusCode == 200 || result.StatusCode == 201)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
