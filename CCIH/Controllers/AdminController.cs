

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

        public ActionResult CreateRegister(UserEnt ent)
        {
            try
            {
                ent.IdRol = 3;
                //var resp = modelCustomer.RegisterCustomer(ent);
                var respIsUser = modelUser.RequestUserByPersonalID(ent.PersonalID);

                if (respIsUser == null )
                {
                    var resp = modelUser.CreateUser(ent);
                    var data = ent;
                    Session["CedulaCliente"] = data.PersonalID;

                    if (resp > 0)
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
                        return View();

                    }
                    else
                    {
                        return View("Error");
                    }

                }
                else
                {
                    return View("The User is already included into the Data Base");
                }

            }
            catch (Exception ex)
            {
                return View("Error");
            }


        }

        public ActionResult ConsultRegistrations()
        {
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
                    Value = item.IdRole.ToString()
                });
            }
            ViewBag.Roles = ComboRoles;

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


            return View();
        }


    }
}

