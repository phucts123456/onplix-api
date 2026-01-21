using AutoMapper;
using MediatR;
using onplix.Application.Interfaces;
using onplix.Application.Queries.Title;
using onplix.Shared.Common;

namespace onplix.Application.Handlers.Title
{
	public class DeleteTitleHandler : IRequestHandler<DeleteTitleQuery, ResponseEntity<string>>
	{
		private readonly ITitleService _titleService;
		public DeleteTitleHandler(
			IMapper mapper,
			ITitleService titleService)
		{
			_titleService = titleService;
		}
		public async Task<ResponseEntity<string>> Handle(DeleteTitleQuery request, CancellationToken cancellationToken)
		{
			var deleteResult = await _titleService.DeleteByIdAsync(request.TitleId);
			if (deleteResult == 0)
			{
				return ResponseEntity<string>.Fail(Constants.MESSAGE_DELETE_TITLE_FAIL);
			}

			return ResponseEntity<string>.Ok(
				Constants.MESSAGE_DELETE_TITLE_SUCCESS,
				Constants.MESSAGE_DELETE_TITLE_SUCCESS);
		}
	}
}
