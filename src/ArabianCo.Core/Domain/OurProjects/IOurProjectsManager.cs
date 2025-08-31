using ArabianCo.Domain.AboutUss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Domain.OurProjects
{
	public interface IOurProjectsManager
	{
		Task<OurProject> GetEntityByIdAsync(int Id);
	}
}
