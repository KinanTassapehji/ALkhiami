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
	public class OurProjectsTranslation : FullAuditedEntity, IEntityTranslation<OurProject>
	{
		public OurProject Core { get; set; }
		public int CoreId { get; set; }
		public string Language { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
