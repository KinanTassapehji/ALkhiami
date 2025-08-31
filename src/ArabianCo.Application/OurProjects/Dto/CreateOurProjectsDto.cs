using ArabianCo.AboutUss.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.OurProjects.Dto
{
	public class CreateOurProjectsDto
	{
		public int AttachmentId { get; set; }
		public List<OurProjectsTranslationDto> Translations { get; set; }
		public string Name { get; set; }
		public string System { get; set; }
		public int? Ton_of_Refrigeration { get; set; }
		public string Location { get; set; }
	}
}
