using AutoMapper;
using MediatR;
using onplix.Application.DTOs.Title;
using onplix.Application.Interfaces;
using onplix.Application.Queries.Title;
using onplix.Shared.Common;

namespace onplix.Application.Handlers.Title
{
	public class InsertTitleHandler : IRequestHandler<InsertTitleQuery, ResponseEntity<TitleDTO>>
	{
		private readonly ITitleService _titleService;
		private readonly IMapper _mapper;
		public InsertTitleHandler(
			IMapper mapper,
			ITitleService titleService)
		{
			_mapper = mapper;
			_titleService = titleService;
		}
		public async Task<ResponseEntity<TitleDTO>> Handle(InsertTitleQuery request, CancellationToken cancellationToken)
		{
			var title = _mapper.Map<Domain.Entities.Title>(request.TitleDto);
			title.Id = Guid.NewGuid();
			var insertResult = await _titleService.InsertAsync(title);

			if (insertResult == 0) return ResponseEntity<TitleDTO>.Fail(Constants.MESSAGE_INSERT_TITLE_FAIL);

			var titleFromDb = _titleService.GetByIdAsync(title.Id);

			var responseData = _mapper.Map<TitleDTO>(titleFromDb);
			return ResponseEntity<TitleDTO>.Ok(responseData);
		}
	}
}
