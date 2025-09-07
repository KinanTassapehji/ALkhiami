using Abp.Domain.Entities.Auditing;
using ArabianCo.Domain.Cities;
using ArabianCo.Authorization.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabianCo.Domain.Addresses
{
	public class Address : FullAuditedEntity
	{
		[Required]
		public int CityId { get; set; }

		[ForeignKey(nameof(CityId))]
		public virtual City City { get; set; }

		[Required]
		public string Street { get; set; }

		[Required]
		public string Area { get; set; }

		public string OtherNotes { get; set; }

		public long? UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual User User { get; set; }
	}
}
