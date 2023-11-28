using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        CustomerModel CustomerModel = new CustomerModel();
        UserModel UserModel = new UserModel();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(UserEnt ent)
        {
            ent.IdRol = 3;
            var data = UserModel.CreateUser(ent);

            return RedirectToAction("SeeCustomers", "Registration");
        }

        [HttpPost]
        public ActionResult EditCustomer(UserEnt ent)
        {
            var data = UserModel.Edituser(ent);
            return RedirectToAction("SeeCustomers", "Registration");
        }

    }
}