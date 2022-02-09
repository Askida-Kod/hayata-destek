using System.Threading.Tasks;
using HayataDestek.Web.Configuration.Dto;

namespace HayataDestek.Web.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
