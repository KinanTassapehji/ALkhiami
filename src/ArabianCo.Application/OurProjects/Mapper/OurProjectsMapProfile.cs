using ArabianCo.Domain.OurProjects;
using ArabianCo.OurProjects.Dto;
using AutoMapper;

namespace ArabianCo.OurProjects.Mapper
{
        internal class OurProjectsMapProfile : Profile
        {
                public OurProjectsMapProfile()
                {
                        CreateMap<CreateOurProjectsDto, OurProject>();
                        CreateMap<UpdateOurProjectsDto, OurProject>();
                        CreateMap<OurProject, OurProjectsDto>();
                        CreateMap<OurProject, LiteOurProjectsDto>();
                        CreateMap<OurProjectsTranslationDto, OurProjectsTranslation>().ReverseMap();
                }
        }
}
