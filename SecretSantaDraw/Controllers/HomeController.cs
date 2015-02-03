using System.Web.Mvc;

namespace SecretSantaDraw.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Secret Santa Draw.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Cool Stuff.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Me.";

            return View();
        }
    }
}
