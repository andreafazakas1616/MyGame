using MyGame.Infrastructure.Models;
using System.Web.Mvc;

namespace MyGame.UI.Controllers
{
    public class HomeController : Controller
    {
       

        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "About Thapratopia Online.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact us at this address:";

            return View();
        }
    }
}