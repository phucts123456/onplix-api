using MediatR;
using onplix.Application.DTOs;
using onplix.Application.Interfaces;
using onplix.Application.Queries.Account;
using onplix.Shared.Common;

namespace onplix.Application.Handlers.Account
{
	public class RegisterAccountHandler
		: IRequestHandler<RegisterAccountQuery, ResponseEntity<AccountDTO>>
	{
		private readonly IAccountService _accountService;
		public RegisterAccountHandler(IAccountService accountService)
		{
			_accountService = accountService;
		}

		public async Task<ResponseEntity<AccountDTO>> Handle(
			RegisterAccountQuery request,
			CancellationToken cancellationToken)
		{
			var loginAccountModel = await _accountService.RegisterAsync(request.accountLoginDTO);
			var result = ResponseEntity<AccountDTO>.Ok(
				loginAccountModel,
				Constants.MESSAGE_LOGIN_SUCCESS);

			return result;
		}
	}
}
