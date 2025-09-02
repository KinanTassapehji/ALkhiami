using System.Threading.Tasks;
using Abp.Application.Services;
using ArabianCo.Sessions.Dto;

namespace ArabianCo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
