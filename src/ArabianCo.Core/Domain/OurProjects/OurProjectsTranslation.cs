using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ArabianCo.Domain.OurProjects
{
	public class OurProjectsTranslation : FullAuditedEntity, IEntityTranslation<OurProject>
	{
		public OurProject Core { get; set; }
		public int CoreId { get; set; }
		public string Language { get; set; }
		public string Name { get; set; }
		public string location { get; set; }
		public string System { get; set; }
		
	}
}
