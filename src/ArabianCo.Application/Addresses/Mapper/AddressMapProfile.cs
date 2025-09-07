using AutoMapper;
using ArabianCo.Addresses.Dto;
using ArabianCo.Domain.Addresses;

namespace ArabianCo.Addresses.Mapper
{
	public class AddressMapProfile : Profile
	{
		public AddressMapProfile()
		{
			CreateMap<Address, AddressDto>();
			CreateMap<Address, LiteAddressDto>();
			CreateMap<CreateAddressDto, Address>();
			CreateMap<UpdateAddressDto, Address>();
		}
	}
}
