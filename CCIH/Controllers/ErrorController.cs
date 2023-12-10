using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult ErrorHome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ErrorAdministration()
        {
            return View();
        }
    }
}