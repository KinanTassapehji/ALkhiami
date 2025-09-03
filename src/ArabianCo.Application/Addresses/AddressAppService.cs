using Abp;
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
            var userId = input.UserId ?? AbpSession.UserId;
            return Repository.GetAll()
                .WhereIf(userId.HasValue, a => a.UserId == userId);
        }

        public override async Task<AddressDto> CreateAsync(CreateAddressDto input)
        {
            input.UserId ??= AbpSession.GetUserId();
            return await base.CreateAsync(input);
        }

        public override async Task<AddressDto> UpdateAsync(UpdateAddressDto input)
        {
            input.UserId ??= (await Repository.GetAsync(input.Id)).UserId;
            return await base.UpdateAsync(input);
        }

        public async Task<ListResultDto<AddressDto>> GetByUserId(long? userId)
        {
            var actualUserId = userId ?? AbpSession.GetUserId();
            var addresses = await Repository.GetAllListAsync(a => a.UserId == actualUserId);
            return new ListResultDto<AddressDto>(ObjectMapper.Map<List<AddressDto>>(addresses));
        }
    }
}
