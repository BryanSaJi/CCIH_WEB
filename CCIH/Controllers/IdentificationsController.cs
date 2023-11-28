
using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    [Authorize]
    public class IdentificationsController : Controller
    {

        IdentificationsModel IdentificationsModel = new IdentificationsModel();


        [HttpGet]
        public List<IdentificationsEnt> ListIdentificationsScrollDown()
        {
            var data = IdentificationsModel.RequestIdentificationsScrollDown();
            return data;
        }

        public ActionResult Index()
        {
            return View();
        }



    }
}