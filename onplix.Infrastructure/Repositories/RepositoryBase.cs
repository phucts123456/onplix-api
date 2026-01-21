using Microsoft.EntityFrameworkCore;
using onplix.Domain.Interfaces;
using onplix.Infrastructure.Data;


namespace onplix.Domain.Repositories
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		private readonly OnPlixDbContext _db;
		private readonly DbSet<T> _dbSet;
		public RepositoryBase(OnPlixDbContext db)
		{
			_db = db;
			_dbSet = db.Set<T>();
		}
		public async Task<T> AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			// tìm entity theo id
			var entity = _dbSet.Find(id);
			if (entity != null)
			{
				// vì T có thể là bất kỳ class nào nên ta dùng reflection để set Deleted = true
				entity.GetType().GetProperty("IsActive")?.SetValue(entity, true);
				_dbSet.Update(entity);
				return true;
			}
			return false;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.Take(20).ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetNAsync(int n)
		{
			return await _dbSet.Take(n).ToListAsync();
		}

		public async Task<T> UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			return entity;
		}
		// save changes
		public async Task<int> SaveChangesAsync()
		{
			return await _db.SaveChangesAsync();
		}
	}
}
