
using CCIH.Entities;
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
            ent.PersonalID = @Session["CedulaCliente"].ToString();
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
        public ActionResult ConsultPreRegisters(PreRegistrationEnt ent)
        {
            var datos = modelRegistration.RequetsPreRegistrations();
            Session["PreRegisterPending"] = datos.Count;


            return View(datos);
        }

        [HttpGet]
        public ActionResult ConsultRegister(long i)
        {
            var data = modelRegistration.RequestRegistration(i);

            //Estatus
            var state = modelState.RequestStatusScrollDown();
            var ComboState = new List<SelectListItem>();
            foreach (var item in state)
            {
                ComboState.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.StatusId.ToString()
                });
            }
            ViewBag.Status = ComboState;


            //Crusos
            var Courses = modelCourse.RequestCourseScrollDown();
            var ComboCourse = new List<SelectListItem>();
            foreach (var item in Courses)
            {
                ComboCourse.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.CourseID.ToString()
                });
            }
            ViewBag.Course = ComboCourse;


            //Modalidad
            var modality = modelModality.RequestModalityScrollDown();
            var ComboModality = new List<SelectListItem>();
            foreach (var item in modality)
            {
                ComboModality.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ModalityId.ToString()
                });
            }
            ViewBag.Modality = ComboModality;

            //Nivel
            var level = modelLevel.RequestLevelCourseScrollDown();
            var ComboLevel = new List<SelectListItem>();
            foreach (var item in level)
            {
                ComboLevel.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.LevelCourseId.ToString()
                });
            }
            ViewBag.Level = ComboLevel;


            //Horario
            var schedule = modelSchedule.RequestScheduleScrollDown();
            var ComboSchedule = new List<SelectListItem>();
            foreach (var item in schedule)
            {
                ComboSchedule.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = item.ScheduleId.ToString()
                });
            }
            ViewBag.Schedule = ComboSchedule;

            //Grupo
            var gorup = modelGroup.RequestGroupScrollDown();
            var ComboGroup = new List<SelectListItem>();
            foreach (var item in gorup)
            {
                ComboGroup.Add(new SelectListItem
                {
                    Text = item.GroupId.ToString(),
                    Value = item.GroupId.ToString()
                });
            }

            ViewBag.Group = ComboGroup;


            return View(data);
        }

        [HttpGet]
        public ActionResult RequestRegistration(long i)
        {
            var data = modelRegistration.RequestRegistration(i);

            //Estatus
            var state = modelState.RequestStatusScrollDown();
            var ComboState = new List<SelectListItem>();
            foreach (var item in state)
            {
                ComboState.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.StatusId.ToString()
                });
            }
            ViewBag.Status = ComboState;


            //Crusos
            var Courses = modelCourse.RequestCourseScrollDown();
            var ComboCourse = new List<SelectListItem>();
            foreach (var item in Courses)
            {
                ComboCourse.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.CourseID.ToString()
                });
            }
            ViewBag.Course = ComboCourse;


            //Modalidad
            var modality = modelModality.RequestModalityScrollDown();
            var ComboModality = new List<SelectListItem>();
            foreach (var item in modality)
            {
                ComboModality.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ModalityId.ToString()
                });
            }
            ViewBag.Modality = ComboModality;

            //Nivel
            var level = modelLevel.RequestLevelCourseScrollDown();
            var ComboLevel = new List<SelectListItem>();
            foreach (var item in level)
            {
                ComboLevel.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.LevelCourseId.ToString()
                });
            }
            ViewBag.Level = ComboLevel;


            //Horario
            var schedule = modelSchedule.RequestScheduleScrollDown();
            var ComboSchedule = new List<SelectListItem>();
            foreach (var item in schedule)
            {
                ComboSchedule.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = item.ScheduleId.ToString()
                });
            }
            ViewBag.Schedule = ComboSchedule;

            //Grupo
            var gorup = modelGroup.RequestGroupScrollDown();
            var ComboGroup = new List<SelectListItem>();
            foreach (var item in gorup)
            {
                ComboGroup.Add(new SelectListItem
                {
                    Text = item.GroupId.ToString(),
                    Value = item.GroupId.ToString()
                });
            }

            ViewBag.Group = ComboGroup;

            

            return View(data);
        }

        [HttpPost]
        public ActionResult EditRegistration(RegistrationEnt ent)
        {
            var resp = modelRegistration.EditRegister(ent);

            if (resp > 0)
                return RedirectToAction("ConsultRegistrations", "Admin");//revisar
            else
            {
                return View("ConsultRegisterToday");
            }
        }

        [HttpGet]
        public ActionResult ContactPreRegistration(int q)
        {
            PreRegistrationEnt ent = new PreRegistrationEnt();
            ent.PreRegistrationId = q;

            var resp = modelRegistration.ContactPreregister(ent);

            if (resp > 0)
                return RedirectToAction("ConsultPreRegister", "Registration");
            else
            {
                return View("Index", "Admin");
            }
        }

        [HttpGet]
        public ActionResult ConsultRegisterToday()
        {
            var data = modelRegistration.RequestRegistrationsToday();
            return View(data);

        }


        [HttpGet]
        public ActionResult SeeCustomers()
        {
            var datos = modelCustomer.SeeCustomers();
            return View(datos);
        }


        [HttpGet]
        public ActionResult SeeCustomer(long i)
        {
            var datos = modelCustomer.SeeCustomer(i);
            Session["CustomerID"] = datos.PersonalID;

            //Estatus
            var Status = modelState.RequestStatusScrollDown();
            var ComboStatus = new List<SelectListItem>();
            foreach (var item in Status)
            {
                ComboStatus.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.StatusId.ToString()
                });
            }
            ViewBag.Status = ComboStatus;


            //Crusos
            var Courses = modelCourse.RequestCourseScrollDown();
            var ComboCourse = new List<SelectListItem>();
            foreach (var item in Courses)
            {
                ComboCourse.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.CourseID.ToString()
                });
            }
            ViewBag.Course = ComboCourse;


            //Modalidad
            var modality = modelModality.RequestModalityScrollDown();
            var ComboModality = new List<SelectListItem>();
            foreach (var item in modality)
            {
                ComboModality.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ModalityId.ToString()
                });
            }
            ViewBag.modality = ComboModality;

            //Nivel
            var level = modelLevel.RequestLevelCourseScrollDown();
            var ComboLevel = new List<SelectListItem>();
            foreach (var item in level)
            {
                ComboLevel.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.LevelCourseId.ToString()
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
                    Text = item.Description,
                    Value = item.ScheduleId.ToString()
                });
            }
            ViewBag.schedule = ComboSchedule;

            //Grupo
            var gorup = modelGroup.RequestGroupScrollDown();
            var ComboGroup = new List<SelectListItem>();
            foreach (var item in gorup)
            {
                ComboGroup.Add(new SelectListItem
                {
                    Text = item.GroupId.ToString(),
                    Value = item.GroupId.ToString()
                });
            }
            ViewBag.gorup = ComboGroup;

            //Roles
            var rol = modelRole.RequestRolesScrollDown();
            var ComboRol = new List<SelectListItem>();
            foreach (var item in rol)
            {
                ComboRol.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdRole.ToString()
                });
            }
            ViewBag.Rol = ComboRol;

            return View(datos);

        }

    }


}