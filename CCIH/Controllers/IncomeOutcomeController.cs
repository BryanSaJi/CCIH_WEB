using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class IncomeOutcomeController : Controller
    {
        IncomeOutcomeModel IncomeOutcomeModel = new IncomeOutcomeModel();


        [HttpGet]
        public List<IncomeOutcomeEnt> ListIncomeOutcomeScrollDown()
        {
            var data = IncomeOutcomeModel.RequestIncomeOutcomeScrollDown();
            return data;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}