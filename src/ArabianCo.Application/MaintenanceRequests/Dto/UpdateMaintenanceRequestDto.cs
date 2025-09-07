using Abp.Application.Services.Dto;

namespace ArabianCo.MaintenanceRequests.Dto;

public class UpdateMaintenanceRequestDto : CreateMaintenanceRequestDto, IEntityDto
{
	public int Id { get; set; }
}
