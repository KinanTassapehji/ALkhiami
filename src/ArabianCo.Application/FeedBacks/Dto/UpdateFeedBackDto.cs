using Abp.Application.Services.Dto;
using ArabianCo.Questions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.FeedBacks.Dto
{
	public class UpdateFeedBackDto : CreateFeedBackDto, IEntityDto
	{
		public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}
