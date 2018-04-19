
namespace CarDealerApp.Controllers
{
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    [RoutePrefix("Suppliers")]
    public class SuppliersController : Controller
    {
        private SuppliersService service;
        public SuppliersController()
        {
            this.service = new SuppliersService();
        }
        [Route("{typeOfSupplier=local}")]
        public ActionResult ShowSuppliers(string typeOfSupplier)
        {
            var model = this.service.GetSuppliers(typeOfSupplier);
            return this.View(model);
        }
    }
}