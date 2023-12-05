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
    public class ReasonController : Controller
    {

        ReasonModel ReasonModel = new ReasonModel();


        [HttpGet]
        public List<ReasonEnt> ListReasonScrollDown()
        {
            var data = ReasonModel.RequestReasonScrollDown();
            return data;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}