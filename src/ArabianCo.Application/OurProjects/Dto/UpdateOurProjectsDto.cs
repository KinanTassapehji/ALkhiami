using Abp.Application.Services.Dto;

namespace ArabianCo.OurProjects.Dto
{
	public class UpdateOurProjectsDto : CreateOurProjectsDto, IEntityDto
	{
		public int Id { get; set; }
	}
}
