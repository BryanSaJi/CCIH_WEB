
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
    public class PaymentTypeController : Controller
    {

        PaymentTypeModel PaymentTypeModel = new PaymentTypeModel();


        [HttpGet]
        public List <PaymentTypeEnt> ListPaymentTypeScrollDown()
        {
            var data = PaymentTypeModel.RequestPaymentTypeScrollDown();
            return data;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}