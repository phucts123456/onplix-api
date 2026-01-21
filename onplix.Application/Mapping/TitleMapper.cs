using AutoMapper;
using onplix.Application.DTOs.Title;
using onplix.Domain.Entities;

namespace onplix.Application.Mapping
{
	public class TitleMapper : Profile
	{
		public TitleMapper()
		{
			CreateMap<Title, TitleDTO>().ReverseMap();
		}
	}
}
