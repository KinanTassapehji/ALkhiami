using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ArabianCo.Domain.AboutUss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Domain.OurProjects
{
	public class OurProject : FullAuditedEntity, IMultiLingualEntity<OurProjectsTranslation>
	{
		public OurProject()
		{
			Translations = new HashSet<OurProjectsTranslation>();
		}
		public ICollection<OurProjectsTranslation> Translations { get; set; }
		public string Name { get; set; }
		public string System { get; set; }
		public int? Ton_of_Refrigeration { get; set; }
		public string Location {  get; set; }

	}
}
