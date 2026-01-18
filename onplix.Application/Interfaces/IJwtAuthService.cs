using onplix.Domain.Entities;

namespace onplix.Application.Interfaces
{
	public interface IJwtAuthService
	{
		string GenerateToken(Account userLogin);
		string DecodePayloadToken(string token);
	}
}
