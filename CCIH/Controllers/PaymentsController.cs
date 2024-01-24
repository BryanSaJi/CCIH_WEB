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


        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult EditPayment(long i)
        {
            try
            {
                var data = model.RequestPayment(i);

                var PaymentType = model.RequestPaymentTypeScrollDown();
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


                var IncomeOutcome = model.RequestIncomeOutcomeScrollDown();
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

                var Motive = model.RequestPaymentMotiveScrollDown();
                var ComboMotive = new List<SelectListItem>();
                foreach (var item in Motive)
                {
                    ComboMotive.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.id_Motive.ToString()
                    });
                }
                ViewBag.Reason = ComboMotive;

                return View();
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }

        }



        [HttpPost]
        public ActionResult EditPayment(PaymentsEnt ent)
        {
            try
            {
                //ent.EmployeeId = long.Parse(Session["IdUser"].ToString());
                var resp = model.EditPayment(ent);

                if (resp > 0)
                {
                    TempData["RespuestaPositivaEditarUsuario"] = true;
                    return RedirectToAction("EditPayment", "Payments", new { i = ent.PaymentsId });
                }
                else
                {
                    TempData["RespuestaNegativaEditarUsuario"] = true;
                    return RedirectToAction("EditPayment", "Payments", new { i = ent.PaymentsId });
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return RedirectToAction("ErrorAdministration", "Error");
            }
        }




        [HttpGet]
        public ActionResult ListPayments()
        {
            try
            {
                var resp = model.ListOfPays();
                return View(resp);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }


        }




        [HttpPost]
        public ActionResult CreatePayment(PaymentsEnt ent)
        {
            try
            {

                //ent.EmployeeId =  long.Parse(Session["IdUser"].ToString());
               //ent.EmployeeId = 7;

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
                return RedirectToAction("ErrorAdministration" ,"");
            }
        }





        [HttpGet]
        public ActionResult CreatePayments()
        {
            try
            {
                var PaymentType = model.RequestPaymentTypeScrollDown();
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


                var IncomeOutcome = model.RequestIncomeOutcomeScrollDown();
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

                var Motive = model.RequestPaymentMotiveScrollDown();
                var ComboMotive = new List<SelectListItem>();
                foreach (var item in Motive)
                {
                    ComboMotive.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.id_Motive.ToString()
                    });
                }
                ViewBag.Reason = ComboMotive;

                return View();
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }
    
    


        [HttpGet]
        public List<PaymentsEnt> ListPaymentsScrollDown()
        {
            var data = model.RequestPaymentsScrollDown();
            return data;
        }


        [HttpGet]
        public List<PaymentsEnt> RequestPaymentMotiveScrollDown()
        {

            var data = model.RequestPaymentMotiveScrollDown();
            return data;
        }

        [HttpGet]
        public List<PaymentsEnt> RequestPaymentTypeScrollDown()
        {
            var data = model.RequestPaymentTypeScrollDown();
            return data;
        }

        [HttpGet]
        public List<PaymentsEnt> RequestIncomeOutcomeScrollDown()
        {
            var data = model.RequestIncomeOutcomeScrollDown();
            return data;
        }


        [HttpGet]
        public ActionResult DeletePayment(long i)
        {
            try
            {
                var resp = model.DeletePayment(i);

                if (resp > 0)
                {
                    Session["MensajePositivo"] = 1;
                    return RedirectToAction("ListPayments", "Payments");
                }
                else
                {
                    Session["MensajeNegativo"] = 1;
                    ViewBag.Msj = "No se ha podido eliminar el pago";
                    return RedirectToAction("ListPayments");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorAdministration", "Error");
            }
        }




    }
}
