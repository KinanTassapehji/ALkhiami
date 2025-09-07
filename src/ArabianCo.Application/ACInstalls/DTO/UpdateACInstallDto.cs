using Abp.Application.Services.Dto;

namespace ArabianCo.ACInstalls.DTO
{
	public class UpdateACInstallDto : CreateACInstallDto, IEntityDto
	{
		public int Id { get; set; }
	}
}
