using System.Threading.Tasks;
using HayataDestek.Web.Models.TokenAuth;
using HayataDestek.Web.Web.Controllers;
using Shouldly;
using Xunit;

namespace HayataDestek.Web.Web.Tests.Controllers
{
    public class HomeController_Tests: WebWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}