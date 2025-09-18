using ArabianCo.Domain.FeedBacks;
using ArabianCo.FeedBacks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ArabianCo.FeedBacks.Mapper
{
	public class FeedBackMapProfile : Profile
	{
		public FeedBackMapProfile()
		{
			CreateMap<CreateFeedBackDto, FeedBack>();
			CreateMap<FeedBack, FeedBackDto>();
		}
	}
}

