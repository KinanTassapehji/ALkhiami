using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
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
            if (!input.UserId.HasValue)
            {
                if (!AbpSession.UserId.HasValue)
                {
                    throw new AbpAuthorizationException("A user must be logged in to create an address");
                }

                input.UserId = AbpSession.UserId.Value;
            }

            return await base.CreateAsync(input);
        }

        public override async Task<AddressDto> UpdateAsync(UpdateAddressDto input)
        {
            if (!input.UserId.HasValue)
            {
                input.UserId = (await Repository.GetAsync(input.Id)).UserId;
            }

            return await base.UpdateAsync(input);
        }

        public async Task<ListResultDto<AddressDto>> GetByUserId(long? userId)
        {
            var actualUserId = userId ?? AbpSession.UserId ?? throw new AbpAuthorizationException("A user must be logged in to retrieve addresses");
            var addresses = await Repository.GetAllListAsync(a => a.UserId == actualUserId);
            return new ListResultDto<AddressDto>(ObjectMapper.Map<List<AddressDto>>(addresses));
        }
    }
}
