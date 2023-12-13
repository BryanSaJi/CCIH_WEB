
using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Windows.Media.Media3D;

namespace CCIH.Controllers
{
    [Authorize]
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
        UserModel modelUser = new UserModel();
        IdentificationsModel modelIdentifications = new IdentificationsModel();


        [HttpPost]
        public ActionResult CreateRegistration(RegistrationEnt ent)
        {
            ent.StatusId = 1;
            //var datos = modelUser.RequestUserByPersonalID(ent.PersonalID);

            //if (datos != null)
            //    ent.UserId = datos.UserId;

            try
            {

                var resp = modelRegistration.CreateRegistration(ent);

                if (resp > 0)
                {
                    @Session["CedulaCliente"] = "";
                    TempData["RespuestaPositivaMatricula"] = true;
                    return RedirectToAction("ConsultRegisterToday");
                }
                else
                {
                    TempData["RespuestaNegativaMatricula"] = true;
                    return RedirectToAction("CreateRegister", "Admin");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return RedirectToAction("ErrorAdministration", "Error");
            }
        }

        [HttpGet]
        public ActionResult ConsultPreRegisters(PreRegistrationEnt ent)
        {
            try
            {
                var datos = modelRegistration.RequetsPreRegistrations();
                Session["PreRegisterPending"] = datos.Count;

                datos = datos.OrderByDescending(x => x.DatePreRegistration).ToList();

                return View(datos);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

        [HttpGet]
        public ActionResult ConsultRegister(long i)
        {

            try
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
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

        [HttpGet]
        public ActionResult RequestRegistration(long i)
        {
            try
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
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

        [HttpPost]
        public ActionResult EditRegistration(RegistrationEnt ent)
        {
            try
            {
                var resp = modelRegistration.EditRegister(ent);

                if (resp > 0)
                {
                    TempData["RespuestaPositivaEditarMatricula"] = true;
                    return RedirectToAction("ConsultRegistrations", "Admin");
                }
                else
                {
                    TempData["RespuestaNegativaEditarMatricula"] = true;
                    return RedirectToAction("ConsultRegistrations", "Admin");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

        [HttpGet]
        public ActionResult ContactPreRegistration(int q)
        {
            try
            {
                PreRegistrationEnt ent = new PreRegistrationEnt();
                ent.PreRegistrationId = q;

                var resp = modelRegistration.ContactPreregister(ent);

                if (resp > 0)
                    return RedirectToAction("ConsultPreRegisters", "Registration");
                else
                {
                    return View("Index", "Admin");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

        [HttpGet]
        public ActionResult ConsultRegisterToday()
        {
            try
            {
                if (TempData.ContainsKey("RespuestaPositivaMatricula"))
                {
                    ViewBag.MsjPantalla = "Matricula Registrada, operacion exitosa";
                    TempData.Remove("RespuestaPositivaMatricula");
                }

                var data = modelRegistration.RequestRegistrationsToday();
                return View(data);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            

        }


        [HttpGet]
        public ActionResult SeeCustomers()
        {
            try
            {
                Session["IdUserCustomerRegistration"] = null;
                var datos = modelUser.RequestUserByRol(3);

                if (datos != null)
                {
                    foreach (var item in datos)
                    {
                        item.StatusName = "Activo";
                    }
                }

                datos = datos.OrderByDescending(x => x.CreationDate).ToList();
                return View(datos);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }

            
        }


        [HttpGet]
        public ActionResult SeeCustomer(long i)
        {
            try
            {
                var datos = modelUser.RequestUser(i);

                var registrations = modelRegistration.RequestRegistrations();
                foreach (var item in registrations)
                {
                    if (item.UserId == i)
                    { Session["IdUserCustomerRegistration"] = item.RegistrationId; }
                }


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
                var rol = modelRole.RequestRoles();
                var ComboRol = new List<SelectListItem>();
                foreach (var item in rol)
                {
                    ComboRol.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.IdRol.ToString()
                    });
                }
                ViewBag.Rol = ComboRol;

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

                return View(datos);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
        }
    }
}