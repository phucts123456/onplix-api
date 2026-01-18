using MediatR;
using onplix.Application.DTOs;
using onplix.Shared.Common;

namespace onplix.Application.Queries.Account
{
	public record RegisterAccountQuery(AccountRegisterDTO accountLoginDTO) : IRequest<ResponseEntity<AccountDTO>>;
}
