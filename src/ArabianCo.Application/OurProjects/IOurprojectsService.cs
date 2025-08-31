using ArabianCo.AboutUss.Dto;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.OurProjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.OurProjects
{
	public interface IOurprojectsService : IArabianCoAsyncCrudAppService<OurProjectsDto, int, OurProjectsDto, PagedOurProjectsResultRequestDto, CreateOurProjectsDto, UpdateOurProjectsDto>
	{
	}
}
