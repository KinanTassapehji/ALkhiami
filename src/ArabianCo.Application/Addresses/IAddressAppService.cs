using System.Threading.Tasks;
using ArabianCo.Addresses.Dto;
using ArabianCo.CrudAppServiceBase;
using Abp.Application.Services.Dto;

namespace ArabianCo.Addresses
{
	public interface IAddressAppService : IArabianCoAsyncCrudAppService<AddressDto, int, LiteAddressDto, PagedAddressResultRequestDto, CreateAddressDto, UpdateAddressDto>
	{
		Task<ListResultDto<AddressDto>> GetByUserId(long? userId);
	}
}
