﻿using BulgarianCreators.Web.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace BulgarianCreators.Tests.Web.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            var hc = new HomeController();

            hc.WithCallTo(x => x.Index()).ShouldRenderView("Index");
        }
    }
}
