using MediatR;
using Microsoft.AspNetCore.Mvc;
using onplix.Application.DTOs.Title;
using onplix.Application.Queries.Title;

namespace onplix.Api.Controllers
{
	[Route("api/title")]
	[ApiController]
	public class TitleController(Mediator _mediator) : ControllerBase
	{
		[HttpPost("insert")]
		public async Task<IActionResult> InsertTitle(TitleDTO titleDTO)
		{
			var result = await _mediator.Send(new InsertTitleQuery(titleDTO));
			if (result.StatusCode == 200 || result.StatusCode == 201)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("update")]
		public async Task<IActionResult> UpdateTitle(TitleDTO titleDTO)
		{
			var result = await _mediator.Send(new UpdateTitleQuery(titleDTO));
			if (result.StatusCode == 200 || result.StatusCode == 201)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public async Task<IActionResult> DeleteTitle([FromRoute]Guid id)
		{
			var result = await _mediator.Send(new DeleteTitleQuery(id));
			if (result.StatusCode == 200 || result.StatusCode == 201)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
