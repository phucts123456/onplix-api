using MediatR;
using onplix.Application.DTOs.Account;
using onplix.Shared.Common;

namespace onplix.Application.Queries.Account
{
	public record RegisterAccountQuery(AccountRegisterDTO accountLoginDTO) : IRequest<ResponseEntity<AccountDTO>>;
}
