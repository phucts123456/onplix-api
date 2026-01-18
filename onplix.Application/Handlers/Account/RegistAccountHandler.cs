using MediatR;
using onplix.Application.DTOs;
using onplix.Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace onplix.Application.Handlers.Account
{
	public record RegistAccountHandler(AccountRegisterDTO AccountRegisterDTO) : IRequest<ResponseEntity<AccountDto>>;
}
