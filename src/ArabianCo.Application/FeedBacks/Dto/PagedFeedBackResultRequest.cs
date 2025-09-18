using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.FeedBacks.Dto
{
	public class PagedFeedBackResultRequest : PagedResultRequestDto
	{
		public bool? IsApproved { get; set; }
	}
}
