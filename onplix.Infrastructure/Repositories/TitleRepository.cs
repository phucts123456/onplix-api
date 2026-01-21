using Microsoft.EntityFrameworkCore;
using onplix.Domain.Entities;
using onplix.Domain.Interfaces;
using onplix.Domain.Repositories;
using onplix.Infrastructure.Data;
using onplix.Shared.Common;

namespace onplix.Infrastructure.Repositories
{
	public class TitleRepository : RepositoryBase<Title>, ITitleRepository
	{
		private readonly OnPlixDbContext _dbContext;
		public TitleRepository(OnPlixDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> InsertAsync(Title title)
		{
			_dbContext.Titles.Add(title);
			var result = await _dbContext.SaveChangesAsync();
			
			return result;
		}

		public async new Task<int> UpdateAsync(Title title)
		{
			_dbContext.Titles.Update(title);
			var result = await _dbContext.SaveChangesAsync();

			return result;
		}

		public async Task<int> DeleteByIdAsync(Guid id)
		{
			var titleFromDB = await GetByIdAsync(id);
			if (titleFromDB == null) return 0;

			titleFromDB.IsActive = Constants.FLAG_INACIVE;
			_dbContext.Titles.Update(titleFromDB);
			var result = await _dbContext.SaveChangesAsync();

			return result;
		}

		public async Task<Title?> GetByIdAsync(Guid id)
		{
			return await _dbContext.Titles.FirstOrDefaultAsync(title => title.Id == id);
		}
	}
}
