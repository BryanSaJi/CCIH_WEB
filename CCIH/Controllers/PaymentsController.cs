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
    public class PaymentsController : Controller
    {
        PaymentsModel model = new PaymentsModel();
        PaymentTypeModel modelPaymentType = new PaymentTypeModel();
        IncomeOutcomeModel modelIncomeOutcome = new IncomeOutcomeModel();
        ReasonModel modelReason = new ReasonModel();


        public ActionResult Index()
        {
            return View();
        }

        // GET: Payments
        [HttpGet]
    public ActionResult ListPayments()
    {
        var data = model.RequestPayment();
        if ((int)Session["MensajePositivo"] == 1)
        {
            ViewBag.MsjPantallaPostivo = "Operacion Exitosa";
        }
        if ((int)Session["MensajeNegativo"] == 1)
        {
            ViewBag.MsjPantallaNegativo = "Operacion sin Exito";
        }
        return View(data);
    }


    [HttpPost]
    public ActionResult CreatePayment(PaymentsEnt ent)
    {
        try
        {

            var resp = model.CreatePayment(ent);

            if (resp > 0)
                return RedirectToAction("ListPayments", "Payments");
            else
            {
                ViewBag.Msj = "No se ha podido registrar su información";
                return View("ListPayments");
            }
        }
        catch (Exception ex)
        {
            return View("Error");
        }
    }



    [HttpGet]
    public ActionResult RegisterPayments()
    {

            var PaymentType = modelPaymentType.RequestPaymentTypeScrollDown();
            var ComboPaymentType = new List<SelectListItem>();
            foreach (var item in PaymentType)
            {
                ComboPaymentType.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.PaymentTypeId.ToString()
                });
            }
            ViewBag.PaymentType = ComboPaymentType;
            

            var IncomeOutcome = modelIncomeOutcome.RequestIncomeOutcomeScrollDown();
            var ComboIncomeOutcome = new List<SelectListItem>();
            foreach (var item in IncomeOutcome)
            {
                ComboIncomeOutcome.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IncomeOutcomeId.ToString()
                });
            }
            ViewBag.IncomeOutcome = ComboIncomeOutcome;

            var Reason = modelReason.RequestReasonScrollDown();
            var ComboReason = new List<SelectListItem>();
            foreach (var item in Reason)
            {
                ComboReason.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ReasonId.ToString()
                });
            }
            ViewBag.Reason = ComboReason;

            return View();
        }
    }


    [HttpGet]
    public ActionResult EditPayment(long i)
    {
        Session["MensajeNegativo"] = 0;
        Session["MensajePositivo"] = 0;
        var data = model.RequestPayment(i);
        return View(data);
    }
    [HttpPost]
    public ActionResult EditPayment(PaymentsEnt ent)
    {
        Session["MensajeNegativo"] = 0;
        Session["MensajePositivo"] = 0;
        try
        {

            var resp = model.EditPayment(ent);

            if (resp > 0)
            {
                Session["MensajePositivo"] = 1;
                return RedirectToAction("ListRoles");
            }

            else
            {
                Session["MensajeNegativo"] = 1;
                return View("ListRoles");
            }
        }
        catch (Exception ex)
        {
            return View("Error");
        }
    }

    [HttpGet]
    public ActionResult DeletePayment(long i)
    {
        try
        {

            var resp = model.DeletePayment(i);

            if (resp > 0)
                return RedirectToAction("ListPayments", "Payments");
            else
            {
                ViewBag.Msj = "No se ha podido eliminar el pago";
                return View("ListPayments");
            }
        }
        catch (Exception ex)
        {
            return View("Error");
        }
    }



    [HttpGet]
    public List<PaymentsEnt> ListPaymentsScrollDown()
    {
        var data = model.RequestPaymentsScrollDown();
        return data;
    }

}
}