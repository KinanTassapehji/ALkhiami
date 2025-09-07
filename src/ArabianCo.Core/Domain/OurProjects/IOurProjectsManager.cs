using System.Threading.Tasks;

namespace ArabianCo.Domain.OurProjects
{
	public interface IOurProjectsManager
	{
		Task<OurProject> GetEntityByIdAsync(int Id);
	}
}
