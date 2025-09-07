using Abp.Application.Services.Dto;
using ArabianCo.Attachments.Dto;
using System.Collections.Generic;

namespace ArabianCo.OurProjects.Dto
{
	public class OurProjectsDto : EntityDto
	{
		public string Name { get; set; }
		public string System { get; set; }
		public int? Ton_of_Refrigeration { get; set; }
		public string Location { get; set; }
		public LiteAttachmentDto Photo { get; set; }
		public List<OurProjectsTranslationDto> Translations { get; set; }
	}
}
