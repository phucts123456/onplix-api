namespace onplix.Application.DTOs.Account
{
	public class AccountLoggedInDTO
	{
		public AccountLoggedInDTO(string token)
		{
			this.Token = token;
		}
		public string Token {  get; set; }
	}
}
