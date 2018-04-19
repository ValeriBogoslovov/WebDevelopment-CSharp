
namespace CarDealerApp.Controllers
{
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Web.Mvc;
    [RoutePrefix("Cars")]
    public class CarsController : Controller
    {
        private CarsService services;
        public CarsController()
        {
            this.services = new CarsService();
        }

        [Route("{make=bmw}")]
        public ActionResult ShowCars(string make)
        {
            IEnumerable<CarsViewModel> model = this.services.GetCars(make);
            return this.View(model);
        }

    }
}