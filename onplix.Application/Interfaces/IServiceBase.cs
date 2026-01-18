namespace onplix.Application.Interfaces
{
	public interface IServiceBase<TEntity, TDto>
		where TEntity : class
		where TDto : class
	{
		// Get all
		Task<List<TDto>> GetAllAsync();
		// Get by id 
		Task<TDto?> GetByIdAsync(int id);
		// Insert entity
		Task<int> Insert(TDto dto);
		// Update entity
		Task<TDto?> Update(TDto dto);
		// Delete by id
		Task<TDto?> Delete(int id);
	}
}
