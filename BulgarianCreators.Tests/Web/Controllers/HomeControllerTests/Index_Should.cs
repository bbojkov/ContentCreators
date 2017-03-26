using BulgarianCreators.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace BulgarianCreators.Tests.Web.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void test()
        {
            var hc = new HomeController();

            hc.WithCallTo(x => x.Index()).ShouldRenderView("Index");
        }
    }
}
