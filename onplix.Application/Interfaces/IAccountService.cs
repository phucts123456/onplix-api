using onplix.Application.DTOs.Account;
using onplix.Domain.Entities;

namespace onplix.Application.Interfaces
{
	public interface IAccountService
	{
		Task<AccountLoggedInDTO> GetLoginTokenAsync(Account account);
		Task<AccountDTO> RegisterAsync(AccountRegisterDTO account);
		Task<Account?> GetUserByEmailAsync(string email);
	}
}
