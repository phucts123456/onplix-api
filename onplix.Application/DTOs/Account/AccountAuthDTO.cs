using System.ComponentModel.DataAnnotations;

namespace onplix.Application.DTOs.Account
{
	public class AccountRegisterDTO
	{
		[Required(ErrorMessage = "Email can not be empty.")]
		[EmailAddress]
		public string Email { get; set; } = null!;

		[Required(ErrorMessage = "Password can not be empty.")]
		[RegularExpression(
			@"^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{6,}$",
			ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter, one number, and one special character.")]
		public string Password { get; set; } = null!;
	}
	public class AccountLoginDTO
	{
		[Required(ErrorMessage = "Email can not be empty.")]
		[EmailAddress]
		public string Email { get; set; } = null!;
		[Required(ErrorMessage = "Password can not be empty.")]
		[RegularExpression(
			@"^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{6,}$",
			ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter, one number, and one special character.")]
		public string Password { get; set; } = null!;
	}
}
