using MediatR;
using onplix.Application.DTOs;
using onplix.Application.Interfaces;
using onplix.Application.Queries.Account;
using onplix.Shared.Common;

namespace onplix.Application.Handlers.Account
{
	public class LoginAccountHandler
		: IRequestHandler<LoginAccountQuery, ResponseEntity<AccountLoggedInDTO>>
	{
		private readonly IAccountService _accountService;
		public LoginAccountHandler(IAccountService accountService)
		{
			_accountService = accountService;
		}

		public async Task<ResponseEntity<AccountLoggedInDTO>> Handle(
			LoginAccountQuery request,
			CancellationToken cancellationToken)
		{
			var loginAccountModel = await _accountService.LoginAsync(request.accountLoginDTO);
			var result = ResponseEntity<AccountLoggedInDTO>.Ok(
				loginAccountModel,
				Constants.MESSAGE_LOGIN_SUCCESS);

			return result;
		}
	}
}
