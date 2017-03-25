using System.Web.Mvc;

namespace BulgarianCreators.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}