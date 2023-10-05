
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

    public class AdminController : Controller
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

        public ActionResult Index()
        {
            var preRegistrationData = modelRegistration.RequetRegistration();
            var TodayRegistrationData = modelRegistration.RequetRegistrationsToday();


            decimal total = 0;
            foreach (var item in TodayRegistrationData)
            {
                total = item.Price;  
            }

            Session["PreRegisterPending"] = preRegistrationData.Count;
            Session["RegisterToday"] = TodayRegistrationData.Count;
            Session["TotalRegisterToday"] = total;

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
                    Value = item.IdRole.ToString()
                });
            }
            ViewBag.Roles = ComboRoles;

            var satate = modelState.RequestStatusScrollDown();
            var ComboState = new List<SelectListItem>();
            foreach (var item in satate)
            {
                ComboState.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdState.ToString()
                });
            }
            ViewBag.satate = ComboState;


            return View();
        }



        public ActionResult CreateRegister(CustomerEnt ent)
        {
            try
            {
                var resp = modelCustomer.RegisterCustomer(ent);
                var data = ent;
                Session["CedulaCliente"] = data.ID;

                if (resp > 0)
                {
                    //Estatus
                    var State = modelState.RequestStatusScrollDown();
                    var ComboState = new List<SelectListItem>();
                    foreach (var item in State)
                    {
                        ComboState.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.IdState.ToString()
                        });
                    }



                    //Crusos
                    var course = modelCourse.ConsultCourseListRolesScrollDown();
                    var ComboCourse = new List<SelectListItem>();
                    foreach (var item in course)
                    {
                        ComboCourse.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.IdCourse.ToString()
                        });
                    }

                    //Modalidad
                    var Modality = modelModality.ConsultModalityListRolesScrollDown();
                    var ComboModality = new List<SelectListItem>();
                    foreach (var item in Modality)
                    {
                        ComboModality.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.IdModality.ToString()
                        });
                    }


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


                    //Horario
                    var Schudule = modelSchedule.RequestScheduleScrollDown();
                    var ComboSchudule = new List<SelectListItem>();
                    foreach (var item in Schudule)
                    {
                        ComboSchudule.Add(new SelectListItem
                        {
                            Text = item.Day,
                            Value = item.IdSchedule.ToString()
                        });
                    }
                    //Grupo
                    var Group = modelGroup.ConsultGroupListRolesScrollDown();
                    var ComboGroup = new List<SelectListItem>();
                    foreach (var item in Group)
                    {
                        ComboGroup.Add(new SelectListItem
                        {
                            Text = item.IdGroup.ToString(),
                            Value = item.IdGroup.ToString()
                        });
                    }


                    ViewBag.Group = ComboGroup;
                    ViewBag.Schudule = ComboSchudule;
                    ViewBag.Level = ComboLevel;
                    ViewBag.Modality = ComboModality;
                    ViewBag.Course = ComboCourse;
                    ViewBag.State = ComboState;
                    return View();

                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }


        }




        public ActionResult RequetRegistration()
        {
            var data = modelRegistration.RequetRegistration();

            return View(data);

        }


      
    }
}

