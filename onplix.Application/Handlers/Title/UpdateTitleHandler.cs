using AutoMapper;
using MediatR;
using onplix.Application.DTOs.Title;
using onplix.Application.Interfaces;
using onplix.Application.Queries.Title;
using onplix.Application.Services;
using onplix.Shared.Common;

namespace onplix.Application.Handlers.Title
{
	public class UpdateTitleHandler : IRequestHandler<UpdateTitleQuery, ResponseEntity<TitleDTO>>
	{
		private readonly ITitleService _titleService;
		private readonly IMapper _mapper;
		public UpdateTitleHandler(
			IMapper mapper,
			ITitleService titleService)
		{
			_mapper = mapper;
			_titleService = titleService;
		}
		public async Task<ResponseEntity<TitleDTO>> Handle(UpdateTitleQuery request, CancellationToken cancellationToken)
		{
			var title = _mapper.Map<Domain.Entities.Title>(request.TitleDto);
			var updateResult = await _titleService.UpdateAsync(title);
			if (updateResult == 0) return ResponseEntity<TitleDTO>.Fail(Constants.MESSAGE_REGISTRATION_SUCCESS);
			var titleFromDb = _titleService.GetByIdAsync(title.Id);

			if (titleFromDb == null)
			{
				return ResponseEntity<TitleDTO>.Fail(Constants.MESSAGE_TITLE_NOT_FOUND, 404);
			}

			var responseData = _mapper.Map<TitleDTO>(titleFromDb);
			return ResponseEntity<TitleDTO>.Ok(responseData);
		}
	}
}
