using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.OurProjects.Dto
{
	public class UpdateOurProjectsDto : CreateOurProjectsDto, IEntityDto
	{
		public int Id { get; set; }
	}
}
