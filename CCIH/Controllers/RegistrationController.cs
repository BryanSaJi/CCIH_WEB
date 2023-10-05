using CCIH.Entities;
using CCIH.Entities.Administracion;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Windows.Media.Media3D;

namespace CCIH.Controllers
{
    public class RegistrationController : Controller
    {
        RoleModel modelRole = new RoleModel();
        StateModel modelState = new StateModel();
        CustomerModel modelCustomer = new CustomerModel();
        CourseModel modelCourse = new CourseModel();
        ModalityModel modelModality = new ModalityModel();
        LevelModel modelLevel = new LevelModel();
        ScheduleModel modelSchedule = new ScheduleModel();
        GroupModel modelGroup = new GroupModel();
        RegistrationModel modelRegistration = new RegistrationModel();

        [HttpPost]
        public ActionResult CreateRegistration(RegistrationEnt ent)
        {

            //revisar sassions
            ent.ID = @Session["CedulaCliente"].ToString();
            try
            {

                var resp = modelRegistration.CreateRegistration(ent);

                if (resp > 0)
                {
                    @Session["CedulaCliente"] = "";
                    return RedirectToAction("ConsultRegisterToday");
                }
                else
                {
                    ViewBag.Msj = "No se ha podido registrar su información";
                    return View("CreateRegister");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult RequetPreRegistration(PreRegistrationEnt ent)
        {
            var datos = modelRegistration.RequetPreRegistration();
            Session["PreRegisterPending"] = datos.Count;


            return View(datos);
        }

        [HttpGet]
        public ActionResult RequetRegistration(long i)
        {
            var data = modelRegistration.RequetRegistrations(i);

            //Estatus
            var state = modelState.RequestStatusScrollDown();
            var ComboState = new List<SelectListItem>();
            foreach (var item in state)
            {
                ComboState.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdState.ToString()
                });
            }
            ViewBag.State = ComboState;


            //Crusos
            var Courses = modelCourse.ConsultCourseListRolesScrollDown();
            var ComboCourse = new List<SelectListItem>();
            foreach (var item in Courses)
            {
                ComboCourse.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdCourse.ToString()
                });
            }
            ViewBag.Course = ComboCourse;


            //Modalidad
            var modality = modelModality.ConsultModalityListRolesScrollDown();
            var ComboModality = new List<SelectListItem>();
            foreach (var item in modality)
            {
                ComboModality.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdModality.ToString()
                });
            }
            ViewBag.modality = ComboModality;

            //Nivel
            var level = modelLevel.ConsultLevelListRolesScrollDown();
            var ComboLevel = new List<SelectListItem>();
            foreach (var item in level)
            {
                ComboLevel.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdLevelCourse.ToString()
                });
            }
            ViewBag.Nivel = ComboLevel;


            //Horario
            var schedule = modelSchedule.RequestScheduleScrollDown();
            var ComboSchedule = new List<SelectListItem>();
            foreach (var item in schedule)
            {
                ComboSchedule.Add(new SelectListItem
                {
                    Text = item.Day,
                    Value = item.IdSchedule.ToString()
                });
            }
            ViewBag.schedule = ComboSchedule;

            //Grupo
            var gorup = modelGroup.ConsultGroupListRolesScrollDown();
            var ComboGroup = new List<SelectListItem>();
            foreach (var item in gorup)
            {
                ComboGroup.Add(new SelectListItem
                {
                    Text = item.IdGroup.ToString(),
                    Value = item.IdGroup.ToString()
                });
            }
            ViewBag.gorup = ComboGroup;

            return View(data);
        }

        [HttpPost]
        public ActionResult EditRegistration(RegistrationEnt ent)
        {
            var resp = modelRegistration.EditRegister(ent);

            if (resp > 0)
                return RedirectToAction("ConsultRegisterToday");//revisar
            else
            {
                return View("ConsultRegisterToday");
            }
        }

        [HttpGet]
        public ActionResult ContactPreRegistration(int q)
        {
            PreRegistrationEnt ent = new PreRegistrationEnt();
            ent.IdPreRegistration = q;

            var resp = modelRegistration.ContactPreregister(ent);

            if (resp > 0)
                return RedirectToAction("ConsultPreRegister", "Matricula");
            else
            {
                return View("Index", "Admin");
            }
        }

        [HttpGet]
        public ActionResult ConsultRegistrationToday()
        {
            var data = modelRegistration.RequetRegistrationsToday();
            return View(data);

        }

    }


}