using AutoMapper;
using onplix.Application.DTOs.Account;
using onplix.Application.Interfaces;
using onplix.Domain.Entities;
using onplix.Domain.Interfaces;

namespace onplix.Application.Services
{
	public class AccountService : IAccountService
	{
		private readonly IMapper _mapper;
		private readonly IAccountRepository _accountRepo;
		private readonly IPasswordHelper _passwordHelper;
		private readonly IJwtAuthService _jwtAuthService;

		public AccountService(
			IMapper mapper,
			IAccountRepository accountRepo,
			IPasswordHelper passwordHelper,
			IJwtAuthService jwtAuthService)
		{
			_mapper = mapper;
			_accountRepo = accountRepo;
			_passwordHelper = passwordHelper;
			_jwtAuthService = jwtAuthService;
		}

		public Task<Account?> GetUserByEmailAsync(string email)
		{
			var account = _accountRepo.GetUserByEmailAsync(email);
			return account;
		}

		public async Task<AccountLoggedInDTO> GetLoginTokenAsync(Account account)
		{
			var token = _jwtAuthService.GenerateToken(account);

			return new AccountLoggedInDTO(token);
		}

		public async Task<AccountDTO> RegisterAsync(AccountRegisterDTO accountRegisterDTO)
		{
			Account newUser = _mapper.Map<Account>(accountRegisterDTO);
			newUser.PasswordHash = _passwordHelper.HashPassword(accountRegisterDTO.Password);
			newUser.AvatarUrl = string.Empty;
			newUser.DisplayName = accountRegisterDTO.Email;
			newUser.MaturityRating = string.Empty;
			newUser.IsActive = true;
			var createUser = await _accountRepo.RegisterAccountAsync(newUser);
			var result = _mapper.Map<AccountDTO>(createUser);

			return result;
		}
	}
}
