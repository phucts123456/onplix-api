using onplix.Application.DTOs.Title;
using onplix.Domain.Entities;

namespace onplix.Application.Interfaces
{
	public interface ITitleService : IServiceBase<Title, TitleDTO>
	{
		Task<int> InsertAsync(Title title);
		Task<int> UpdateAsync(Title title);
		Task<int> DeleteByIdAsync(Guid id);
		Task<Title?> GetByIdAsync(Guid id);
	}
}
