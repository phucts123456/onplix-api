using onplix.Domain.Entities;

namespace onplix.Domain.Interfaces
{
	public interface IAccountRepository
	{
		Task<Account> RegisterAccountAsync(Account user);
		Task<Account?> GetUserByEmailAsync(string email);
	}
}
