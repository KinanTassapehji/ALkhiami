using Abp.Application.Services.Dto;
using ArabianCo.Attachments.Dto;

namespace ArabianCo.OurProjects.Dto
{
        public class LiteOurProjectsDto : EntityDto
        {
                public string Name { get; set; }
                public string System { get; set; }
                public string Location { get; set; }
                public LiteAttachmentDto Photo { get; set; }
        }
}
