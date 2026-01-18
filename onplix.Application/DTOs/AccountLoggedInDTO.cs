namespace onplix.Application.DTOs
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
