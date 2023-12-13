using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CCIH.Controllers
{
    public class ScheduleController : Controller
    {

        ScheduleModel scheduleModel = new ScheduleModel();

        [HttpGet]
        public ActionResult ShowSchedules()
        {
            var Data = scheduleModel.RequestScheduleScrollDown();

            if ((int)Session["MensajePositivo"] == 1)
            {

                ViewBag.MsjPantallaPostivo = "El horario fue agregado de manera correcta.";
            }


            if ((int)Session["MensajeNegativo"] == 2)
            {

                ViewBag.MsjPantallaNegativo = "No se ha podido agregar el horario.";
            }

            if ((int)Session["MensajePositivo"] == 3)
            {

                ViewBag.MsjPantallaPostivo = "El horario fue modificado de manera correcta.";
            }


            if ((int)Session["MensajeNegativo"] == 2)
            {

                ViewBag.MsjPantallaNegativo = "No se ha podido modificar el horario.";
            }


            return View(Data);
        }


        [AllowAnonymous]
        public ActionResult EditSchedule(string description, string LastDescription)
        {

            var ScheduleId = scheduleModel.SeeSchedulesByDescription(LastDescription);

            var Data = 0;

            if (description.IsEmpty() || ScheduleId <= 0)
            {
                Session["MensajeNegativo"] = 4;
            }
            else
            {
                

                Data = scheduleModel.EditSchedule(ScheduleId, description);

                if (Data > 0)
                {
                    Session["MensajePositivo"] = 3;
                }
                else
                {
                    Session["MensajeNegativo"] = 4;
                }
            }


            // Convertir la lista de cursos a JSON
            var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);


            // Devolver los datos JSON
            return jsonCursos;
        }

        [AllowAnonymous]
        public ActionResult DeleteSchedule(long scheduleId)
        {
            var Data = scheduleModel.DeleteSchedule(scheduleId);

            return View(Data);
        }



        [HttpPost]
        public ActionResult CreateSchedule(ScheduleEnt scheduleEnt)
        {

            var scheduleId = scheduleModel.SeeSchedulesByDescription( scheduleEnt.Description );

            if (scheduleId == 0)
            {

                var Data = scheduleModel.CreateSchedule(scheduleEnt);

                if (Data > 0)
                {
                    Session["MensajePositivo"] = 1;
                }
                else
                {
                    Session["MensajeNegativo"] = 2;
                }

                

                // Convertir la lista de cursos a JSON
                var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);

                // Devolver los datos JSON
                return jsonCursos;
            }
            else
            {
                Session["MensajeNegativo"] = 2;

                var Data = 0;

                // Convertir la lista de cursos a JSON
                var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);

                // Devolver los datos JSON
                return jsonCursos;
            }

            
        }




    }
}