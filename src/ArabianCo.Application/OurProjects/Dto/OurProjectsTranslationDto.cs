using Abp.AutoMapper;
using ArabianCo.Domain.OurProjects;
using System.ComponentModel.DataAnnotations;

namespace ArabianCo.OurProjects.Dto
{
	[AutoMap(typeof(OurProjectsTranslation))]
	public class OurProjectsTranslationDto
	{
		[Required]
		public string Language { get; set; }
		[Required]
		public string Name { get; set; }
                [Required]
                public string System { get; set; }
                [Required]
                public string Location { get; set; }
	}
}
