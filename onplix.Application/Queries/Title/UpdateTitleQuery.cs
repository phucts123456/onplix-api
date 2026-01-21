using MediatR;
using onplix.Application.DTOs.Title;
using onplix.Shared.Common;

namespace onplix.Application.Queries.Title
{
	public record UpdateTitleQuery(TitleDTO TitleDto) : IRequest<ResponseEntity<TitleDTO>>;
}
