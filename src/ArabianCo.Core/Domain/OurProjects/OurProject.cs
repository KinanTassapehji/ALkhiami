using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace ArabianCo.Domain.OurProjects
{
	public class OurProject : FullAuditedEntity, IMultiLingualEntity<OurProjectsTranslation>
	{
		public OurProject()
		{
			Translations = new HashSet<OurProjectsTranslation>();
		}
                public ICollection<OurProjectsTranslation> Translations { get; set; }
                public int? Ton_of_Refrigeration { get; set; }

        }
}
