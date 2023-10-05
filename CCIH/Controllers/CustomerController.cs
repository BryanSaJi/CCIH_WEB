using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class CustomerController : Controller
    {
        CustomerModel CustomerModel = new CustomerModel();


        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditCustomer(CustomerEnt ent)
        {
            var data = CustomerModel.EditCustomer(ent);
            return RedirectToAction("SeeCustomers", "Registration");
        }

    }
}