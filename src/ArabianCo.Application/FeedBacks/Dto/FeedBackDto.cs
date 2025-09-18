using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.FeedBacks.Dto
{
	public class FeedBackDto : EntityDto
	{
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public string TheFeedBack { get; set; }
		public bool IsApproved { get; set; }
	}
}
