using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using ArabianCo.Addresses.Dto;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.Domain.Addresses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArabianCo.Addresses
{
    public class AddressAppService : ArabianCoAsyncCrudAppService<Address, AddressDto, int, LiteAddressDto, PagedAddressResultRequestDto, CreateAddressDto, UpdateAddressDto>, IAddressAppService
    {
        public AddressAppService(IRepository<Address, int> repository) : base(repository)
        {
        }

        protected override IQueryable<Address> CreateFilteredQuery(PagedAddressResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(input.UserId.HasValue, a => a.UserId == input.UserId);
        }

        public override async Task<AddressDto> CreateAsync(CreateAddressDto input)
        {
            if (!input.UserId.HasValue && AbpSession.UserId.HasValue)
            {
                input.UserId = AbpSession.UserId.Value;
            }

            return await base.CreateAsync(input);
        }

        public override async Task<AddressDto> UpdateAsync(UpdateAddressDto input)
        {
            return await base.UpdateAsync(input);
        }

        public async Task<ListResultDto<AddressDto>> GetByUserId(long? userId)
        {
            var addresses = await Repository.GetAllListAsync(a => a.UserId == userId);
            return new ListResultDto<AddressDto>(ObjectMapper.Map<List<AddressDto>>(addresses));
        }
    }
}
