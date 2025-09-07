using ArabianCo.ACInstalls.DTO;
using ArabianCo.CrudAppServiceBase;

namespace ArabianCo.ACInstalls
{
	public interface IACInstallAppService : IArabianCoAsyncCrudAppService<ACInstallDto, int, LiteACInstallDto, PagedACInstallResultDto, CreateACInstallDto, UpdateACInstallDto>
	{
	}
}
