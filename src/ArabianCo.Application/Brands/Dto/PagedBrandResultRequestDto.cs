using Abp.Application.Services.Dto;

namespace ArabianCo.Brands.Dto;

public class PagedBrandResultRequestDto : PagedResultRequestDto
{
	public bool? IsActive { get; set; }
}

