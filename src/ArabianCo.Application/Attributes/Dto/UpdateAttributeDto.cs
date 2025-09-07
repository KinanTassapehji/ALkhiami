using Abp.Application.Services.Dto;

namespace ArabianCo.Attributes.Dto;

public class UpdateAttributeDto : CreateAttributeDto, IEntityDto
{
	public int Id { get; set; }
}
