using AutoMapper;
using onplix.Application.DTOs;
using onplix.Domain.Entities;

namespace onplix.Application.Mapping
{
	public class AccountMapper : Profile
	{
		public AccountMapper()
		{
			CreateMap<Account, AccountRegisterDTO>().ReverseMap();
			CreateMap<AccountRegisterDTO, Account>()
				.ForMember(vm => vm.PasswordHash, opt => opt.Ignore())
				.ForMember(vm => vm.CreatedAt, opt => opt.MapFrom(dto => DateTime.Now));
			CreateMap<Account, AccountDTO>();
		}
	}
}
