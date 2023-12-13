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
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

        [HttpPost]
        public ActionResult CreateCustomer(UserEnt ent)
        {
            try
            {
                ent.IdRol = 3;
                var data = UserModel.CreateUser(ent);

                return RedirectToAction("SeeCustomers", "Registration");
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

        [HttpPost]
        public ActionResult EditCustomer(UserEnt ent)
        {
            try
            {
                var data = UserModel.EditUser(ent);
                return RedirectToAction("SeeCustomers", "Registration");
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

    }
}