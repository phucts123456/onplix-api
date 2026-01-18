using onplix.Domain.Entities;
using onplix.Domain.Interfaces;
using onplix.Infrastructure.Data;

namespace onplix.Infrastructure.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly OnPlixDbContext _context;

		public AccountRepository(OnPlixDbContext context)
		{
			_context = context;
		}

		public async Task<Account?> GetUserByEmailAsync(string email)
		{
			var accountFromDB = _context.Accounts.FirstOrDefault(account => account.Email == email);
			return accountFromDB;
		}

		public async Task<Account> RegisterAccountAsync(Account user)
		{
			await _context.Accounts.AddAsync(user);
			await _context.SaveChangesAsync();
			return user;
		}
	}
}
