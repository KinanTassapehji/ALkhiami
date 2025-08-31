using ArabianCo.OurProjects.Dto;
using AutoMapper;
using ArabianCo.Domain.OurProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.OurProjects.Mapper
{
	internal class OurProjectsMapProfile : Profile
	{
		public OurProjectsMapProfile()
		{
			CreateMap<CreateOurProjectsDto, OurProject>();
			CreateMap<UpdateOurProjectsDto, OurProject>();
		}
	}
}
