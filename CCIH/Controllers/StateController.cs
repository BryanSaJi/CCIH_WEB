
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
    public class StateController : Controller
    {

        StateModel StatusModel = new StateModel();


        [HttpGet]
        public List<StatusEnt> ListStateScrollDown()
        {
            var data = StatusModel.RequestStatusScrollDown();
            return data;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}