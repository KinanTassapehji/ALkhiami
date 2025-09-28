using System.Collections.Generic;

namespace ArabianCo.OurProjects.Dto
{
	public class CreateOurProjectsDto
	{
		public int AttachmentId { get; set; }
                public List<OurProjectsTranslationDto> Translations { get; set; }
                public int? Ton_of_Refrigeration { get; set; }
	}
}
