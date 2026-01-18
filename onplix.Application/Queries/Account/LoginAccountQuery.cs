using MediatR;
using onplix.Application.DTOs;
using onplix.Shared.Common;

namespace onplix.Application.Queries.Account
{
	public record LoginAccountQuery(AccountLoginDTO accountLoginDTO) : IRequest<ResponseEntity<AccountLoggedInDTO>>;
}
