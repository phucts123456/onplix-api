using onplix.Application.DTOs.Title;
using onplix.Domain.Entities;

namespace onplix.Application.Interfaces
{
	public class ITitleService : IServiceBase<Title, TitleDTO>
	{
		public Task<TitleDTO?> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<TitleDTO>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<TitleDTO?> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<TitleDTO?> Update(TitleDTO dto)
		{
			throw new NotImplementedException();
		}

		Task<int> Insert(TitleDTO dto)
		{
			throw new NotImplementedException();
		}
	}
}
