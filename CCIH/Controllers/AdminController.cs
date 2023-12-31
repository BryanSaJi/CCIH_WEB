﻿

using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Windows.Media.Media3D;

namespace CCIH.Controllers
{
    [Authorize]
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
            try {
                Session["MensajePositivo"] = 0;
                Session["MensajeNegativo"] = 0;
                if (Session["IdRoleUser"].ToString() == "1")
                {

                    var preRegistrationData = modelRegistration.RequetsPreRegistrations();
                    var TodayRegistrationData = modelRegistration.RequestRegistrationsToday();

                    decimal total = 0;
                    foreach (var item in TodayRegistrationData)
                    {
                        total = item.Amount + total;
                    }
                    Session["CedulaCliente"] = null;
                    Session["PreRegisterPending"] = preRegistrationData.Count;
                    Session["RegisterToday"] = TodayRegistrationData.Count;
                    Session["TotalRegisterToday"] = total;
                    Session["CedulaCliente"] = "";

                    return View();
                }
                else
                {
                    int userId = Convert.ToInt32(Session["UserId"]);
                    var data = modelUser.RequestUser(userId);
                    return View(data);


                }
            }
            catch (Exception ex) {
                var exept = ex.Message;

                return RedirectToAction("ErrorHome", "Error");
            }
            

            
        }

        public ActionResult CreateRole()
        {
            try
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
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
        }

        public ActionResult CreateRegister()
        {
            try
            {//Status
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
                    if (item.CourseID <= 3)
                    {
                        ComboCourse.Add(new SelectListItem
                        {
                            Text = item.CourseName,
                            Value = item.CourseID.ToString()
                        });
                    }
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

                if (TempData.ContainsKey("RespuestaNegativaMatricula"))
                {
                    ViewBag.MsjPantalla = "No existe cliente o usuario con dicha cedula, por favor cree primero el usuario";
                    TempData.Remove("RespuestaNegativaMatricula");
                }

                return View();
            }catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
                
        }
    
        public ActionResult ConsultRegistrations()
        {
            try
            {
                if (TempData.ContainsKey("RespuestaPositivaEditarMatricula"))
                {
                    ViewBag.MsjPantallaPositivo = "Informacion de la matricula actualizada.";
                    TempData.Remove("RespuestaPositivaEditarMatricula");
                }
                if (TempData.ContainsKey("RespuestaNegativaEditarMatricula"))
                {
                    ViewBag.MsjPantallaNegativo = "No se pudo actualizar la matricula.";
                    TempData.Remove("RespuestaNegativaEditarMatricula");
                }

                var data = modelRegistration.RequestRegistrations();
                data = data.OrderByDescending(x => x.RegistrationDate).ToList();

                return View(data);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }

        }

        public ActionResult Customer()
        {
            try
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
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }


    }
}

