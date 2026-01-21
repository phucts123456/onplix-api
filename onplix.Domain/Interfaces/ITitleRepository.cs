using onplix.Domain.Entities;

namespace onplix.Domain.Interfaces
{
	public interface ITitleRepository
	{
		public Task<Title?> GetByIdAsync(Guid id);
		public Task<int> InsertAsync(Title title);
		public Task<int> UpdateAsync(Title title);
		public Task<int> DeleteByIdAsync(Guid id);
	}
}
