namespace onplix.Application.Interfaces
{
	public interface IServiceBase<TEntity, TDto>
		where TEntity : class
		where TDto : class
	{
		Task<List<TDto>> GetAllAsync();
		// get by id 
		Task<TDto?> GetByIdAsync(int id);
	}
}
