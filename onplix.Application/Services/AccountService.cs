using AutoMapper;
using onplix.Application.DTOs;
using onplix.Application.Interfaces;
using onplix.Domain.Entities;
using onplix.Domain.Interfaces;
using onplix.Shared.Common;

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

		public async Task<AccountLoggedInDTO> LoginAsync(AccountLoginDTO accountLoginDTO)
		{
			Account? accountFromDB = await _accountRepo.GetUserByEmailAsync(accountLoginDTO.Email);
			if (accountFromDB == null)
			{
				ResponseEntity<AccountDTO>.Fail(Constants.ERROR_MESSAGE_WRONG_USERNAME_OR_PASSWORD);
			}

			if (accountFromDB!.PasswordHash != _passwordHelper.HashPassword(accountLoginDTO.Password))
			{
				ResponseEntity<AccountDTO>.Fail(Constants.ERROR_MESSAGE_WRONG_USERNAME_OR_PASSWORD);
			}
			var token = _jwtAuthService.GenerateToken(accountFromDB);

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
