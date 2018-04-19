
namespace CarDealerApp.Controllers
{
    using CarDealer.Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    [RoutePrefix("customers")]
    public class CustomersController : Controller
    {
        [Route("all/{orderType=ascending}")]
        public ActionResult All(string orderType)
        {
            List<CustomersViewModel> model = new List<CustomersViewModel>();
            using (var context = new CarDealerContext())
            {
                if (orderType == "ascending")
                {
                    model = context.Customers.OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver)
                        .Select(c => new CustomersViewModel()
                        {
                            Name = c.Name,
                            BirthDate = c.BirthDate,
                            IsYoungDriver = c.IsYoungDriver
                        }).ToList();
                }
                else if (orderType == "descending")
                {
                    model = context.Customers.OrderByDescending(c => c.BirthDate).ThenByDescending(c => c.IsYoungDriver)
                        .Select(c => new CustomersViewModel()
                        {
                            Name = c.Name,
                            BirthDate = c.BirthDate,
                            IsYoungDriver = c.IsYoungDriver
                        }).ToList();
                }
            }
            return View(model);
        }
    }
}