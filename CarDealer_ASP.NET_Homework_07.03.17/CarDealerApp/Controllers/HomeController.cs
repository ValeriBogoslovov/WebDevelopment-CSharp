

namespace CarDealerApp.Controllers
{
    using CarDealer.Data;
    using System.Linq;
    using System.Web.Mvc;
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var ctx = new CarDealerContext();
            ViewBag.Message = "Your application description page.\nCars count:" + ctx.Cars.Count();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}