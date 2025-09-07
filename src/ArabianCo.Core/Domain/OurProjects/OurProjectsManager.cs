using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArabianCo.Domain.OurProjects
{
	internal class OurProjectsManager : DomainService, IOurProjectsManager
	{
		private readonly IRepository<OurProject> _repository;

		public OurProjectsManager(IRepository<OurProject> repository)
		{
			_repository = repository;
		}
		public Task<OurProject> GetEntityByIdAsync(int Id)
		{
			var entity = _repository.GetAll().Where(x => x.Id == Id).Include(x => x.Translations).FirstOrDefaultAsync();
			if (entity == null)
				throw new EntityNotFoundException(typeof(OurProject), Id);
			return entity;
		}
	}
}
