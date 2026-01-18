using onplix.Application.DTOs;
using onplix.Shared.Common;

namespace onplix.Application.Interfaces
{
	public interface IAccountService
	{
		Task<AccountLoggedInDTO> LoginAsync(AccountLoginDTO account);
		Task<AccountDto> RegisterAsync(AccountRegisterDTO account);
	}
}
