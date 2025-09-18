using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Domain.FeedBacks
{
	public class FeedBack : FullAuditedEntity
	{
		[Required]
		[StringLength(AbpUserBase.MaxNameLength)]
		public string FullName { get; set; }
		[Required]
		[StringLength(AbpUserBase.MaxPhoneNumberLength)]
		public string PhoneNumber { get; set; }
		[Required]
		[StringLength(200)]
		public string TheFeedBack { get; set; }
		[DefaultValue(false)]
		public bool IsApproved { get; set; }
	}
}
