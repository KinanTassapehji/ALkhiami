using Abp.Application.Services.Dto;

namespace ArabianCo.ACInstalls.DTO
{
	public class PagedACInstallResultDto : PagedResultRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public string phoneNumber { get; set; }
	}
}
