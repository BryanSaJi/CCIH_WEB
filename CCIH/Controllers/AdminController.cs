

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

    public class AdminController : Controller
    {
        RoleModel modelRole = new RoleModel();
        IdentificationsModel modelIdentifications = new IdentificationsModel();
        StateModel modelState = new StateModel();
        CustomerModel modelCustomer = new CustomerModel();
        CourseModel modelCourse = new CourseModel();
        ModalityModel modelModality = new ModalityModel();
        LevelModel modelLevel = new LevelModel();
        ScheduleModel modelSchedule = new ScheduleModel();
        GroupModel modelGroup = new GroupModel();
        RegistrationModel modelRegistration = new RegistrationModel();
        UserModel modelUser = new UserModel();

        public ActionResult Index()
        {
            var preRegistrationData = modelRegistration.RequetsPreRegistrations();
            var TodayRegistrationData = modelRegistration.RequestRegistrationsToday();


            decimal total = 0;
            foreach (var item in TodayRegistrationData)
            {
                total = item.Amount;
            }
            Session["MensajePositivo"] = 0;
            Session["MensajeNegativo"] = 0;
            Session["CedulaCliente"] = null;
            Session["PreRegisterPending"] = preRegistrationData.Count;
            Session["RegisterToday"] = TodayRegistrationData.Count;
            Session["TotalRegisterToday"] = total;
            Session["CedulaCliente"] = "";

            return View();
        }

        public ActionResult CreateRole()
        {

            var roles = modelRole.RequestRolesScrollDown();
            var ComboRoles = new List<SelectListItem>();
            foreach (var item in roles)
            {
                ComboRoles.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdRol.ToString()
                });
            }
            ViewBag.Roles = ComboRoles;

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
            ViewBag.state = ComboState;


            return View();
        }

        public ActionResult CreateRegister()
        {

                //Status
                var State = modelState.RequestStatusScrollDown();
                var ComboState = new List<SelectListItem>();
                foreach (var item in State)
                {
                    ComboState.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.StatusId.ToString()
                    });
                }

                //Crusos
                var course = modelCourse.RequestCourseScrollDown();
                var ComboCourse = new List<SelectListItem>();
                foreach (var item in course)
                {
                    ComboCourse.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.CourseID.ToString()
                    });
                }

                //Modalidad
                var Modality = modelModality.RequestModalityScrollDown();
                var ComboModality = new List<SelectListItem>();
                foreach (var item in Modality)
                {
                    ComboModality.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ModalityId.ToString()
                    });
                }

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

                //Horario
                var Schudule = modelSchedule.RequestScheduleScrollDown();
                var ComboSchudule = new List<SelectListItem>();
                foreach (var item in Schudule)
                {
                    ComboSchudule.Add(new SelectListItem
                    {
                        Text = item.Description,
                        Value = item.ScheduleId.ToString()
                    });
                }

                //Grupo
                var Group = modelGroup.RequestGroupScrollDown();
                var ComboGroup = new List<SelectListItem>();
                foreach (var item in Group)
                {
                    ComboGroup.Add(new SelectListItem
                    {
                        Text = item.GroupId.ToString(),
                        Value = item.GroupId.ToString()
                    });
                }


                ViewBag.Group = ComboGroup;
                ViewBag.Schedule = ComboSchudule;
                ViewBag.Level = ComboLevel;
                ViewBag.Modality = ComboModality;
                ViewBag.Course = ComboCourse;
                ViewBag.Status = ComboState;

                if ((int)Session["MensajePositivo"] == 1)
                {
                    
                    ViewBag.MsjPantallaPostivo = "Usuario Registrado, proceda con la matricula";
                }

                if ((int)Session["MensajeNegativo"] == 1)
                {
                    
                    ViewBag.MsjPantallaNegativo = "No se ha efectuado la matricula debido a un problema con el usuario ingresado";
                }

            return View();
        }
    

        

        public ActionResult ConsultRegistrations()
        {
            if ((int)Session["MensajePositivo"] == 1)
            {
                ViewBag.MsjPantallaPostivo = "Se ha actualizado la informacion de la matricula";
            }
            if ((int)Session["MensajeNegativo"] == 1)
            {
                ViewBag.MsjPantallaNegativo = "No se ha actualizado la informacion de la matricula";
            }

            var data = modelRegistration.RequestRegistrations();

            return View(data);

        }

        public ActionResult Customer()
        {

            var roles = modelRole.RequestRolesScrollDown();
            var ComboRoles = new List<SelectListItem>();
            foreach (var item in roles)
            {
                ComboRoles.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdRol.ToString()
                });
            }
            ViewBag.Rol = ComboRoles;

            var State = modelState.RequestStatusScrollDown();
            var ComboState = new List<SelectListItem>();
            foreach (var item in State)
            {
                ComboState.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.StatusId.ToString()
                });
            }
            ViewBag.State = ComboState;

            var Identifications = modelIdentifications.RequestIdentificationsScrollDown();
            var ComboIdentifications = new List<SelectListItem>();
            foreach (var item in Identifications)
            {
                ComboIdentifications.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdentificationsId.ToString()
                });
            }
            ViewBag.Identifications = ComboIdentifications;

            return View();
        }


    }
}

