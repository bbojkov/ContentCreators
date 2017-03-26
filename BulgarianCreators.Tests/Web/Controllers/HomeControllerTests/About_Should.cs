using BulgarianCreators.Web.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace BulgarianCreators.Tests.Web.Controllers.HomeControllerTests
{
    [TestFixture]
    public class About_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            var hc = new HomeController();

            hc.WithCallTo(x => x.About()).ShouldRenderView("About");
        }
    }
}
