using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ArabianCo.Domain.Addresses;

namespace ArabianCo.Addresses.Dto
{
    [AutoMapFrom(typeof(Address))]
    public class LiteAddressDto : EntityDto<int>
    {
        public string Street { get; set; }
        public string Area { get; set; }
        public long UserId { get; set; }
    }
}
