using onplix.Application.Interfaces;
using onplix.Domain.Entities;
using onplix.Domain.Interfaces;

namespace onplix.Application.Services
{
	public class TitleService : ITitleService
	{
		private readonly ITitleRepository _titleRepo;

		public TitleService(ITitleRepository titleRepo)
		{
			_titleRepo = titleRepo;
		}

		public async Task<Title?> GetByIdAsync(Guid id)
		{
			return await _titleRepo.GetByIdAsync(id);
		}

		public Task<int> InsertAsync(Title title)
		{
			return _titleRepo.InsertAsync(title);
		}

		public Task<int> UpdateAsync(Title title)
		{
			return _titleRepo.UpdateAsync(title);
		}
		public Task<int> DeleteByIdAsync(Guid id)
		{
			return _titleRepo.DeleteByIdAsync(id);
		}
	}
}
