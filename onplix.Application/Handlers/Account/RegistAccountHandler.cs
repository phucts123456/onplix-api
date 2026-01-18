using MediatR;
using onplix.Application.DTOs.Account;
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
			var accountFromDB = await _accountService.GetUserByEmailAsync(request.accountLoginDTO.Email);
			if ((accountFromDB != null)
				&& (accountFromDB.Email == request.accountLoginDTO.Email))
			{
				return ResponseEntity<AccountDTO>.Fail(Constants.MESSAGE_REGISTRATION_FAIL_EMAIL_EXISTED);
			}
			var loginAccountModel = await _accountService.RegisterAsync(request.accountLoginDTO);

			return ResponseEntity<AccountDTO>.Ok(
				loginAccountModel,
				Constants.MESSAGE_LOGIN_SUCCESS); ;
		}
	}
}
