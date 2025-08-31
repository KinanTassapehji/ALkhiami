using Abp.AutoMapper;
using ArabianCo.Domain.AboutUss;
using ArabianCo.Domain.OurProjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public int? Ton_of_Refrigeration { get; set; }
		[Required]
		public string Location { get; set; }
	}
}
