using System.Threading.Tasks;
using Abp.Application.Services;
using HayataDestek.Web.Sessions.Dto;

namespace HayataDestek.Web.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
