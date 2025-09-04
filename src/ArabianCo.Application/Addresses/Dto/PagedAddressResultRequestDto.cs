using Abp.Application.Services.Dto;

namespace ArabianCo.Addresses.Dto
{
    public class PagedAddressResultRequestDto : PagedResultRequestDto
    {
        public long? UserId { get; set; }
    }
}
