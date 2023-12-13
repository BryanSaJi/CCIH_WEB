using CCIH.Entities;
using CCIH.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls.Primitives;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace CCIH.Controllers
{
    public class GroupController : Controller
    {

        GroupModel GroupModel = new GroupModel();
        StateModel StateModel = new StateModel();
        CourseModel CourseModel = new CourseModel();
        UserModel UserModel = new UserModel();
        ScheduleModel ScheduleModel = new ScheduleModel();


        // GET: Group
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }



        [Authorize]
        [HttpGet]
        public ActionResult SetPeople(bool init, long groupIdP)
        {
            try
            {
                var DataStudents = UserModel.SeeAllUserStudentsOutGroup();



                //Groups
                var Group = GroupModel.RequestGroupScrollDown();

                var ComboGroup = new List<SelectListItem>();




                if (init)
                {
                    ComboGroup.Add(new SelectListItem
                    {
                        Text = "Seleccionar Grupo",
                        Value = 0.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    ComboGroup.Add(new SelectListItem
                    {
                        Text = "Seleccionar Grupo",
                        Value = 0.ToString()
                    });
                }

                foreach (var item in Group)
                {
                    if (init)
                    {
                        ComboGroup.Add(new SelectListItem
                        {
                            Text = item.GroupName,
                            Value = item.GroupId.ToString(),

                        });
                    }
                    else
                    {
                        ComboGroup.Add(new SelectListItem
                        {
                            Text = item.GroupName,
                            Value = item.GroupId.ToString(),
                            Selected = true
                        });
                    }

                }
                ViewBag.Group = ComboGroup;


                //Teacher
                var Teacher = UserModel.SeeAllUserTeacher();
                var ComboTeacher = new List<SelectListItem>();


                if (init)
                {
                    ComboTeacher.Add(new SelectListItem
                    {
                        Text = "Sin Profesor",
                        Value = 0.ToString(),
                        Selected = true
                    });
                }
                else
                {

                    var dataGroups = GroupModel.SeeGroupsByGroupId(groupIdP);
                    if (dataGroups.TeacherId == 0)
                    {
                        ComboTeacher.Add(new SelectListItem
                        {
                            Text = "Sin Profesor",
                            Value = 0.ToString(),
                            Selected = true
                        });
                    }
                }

                foreach (var item in Teacher)
                {
                    if (init)
                    {
                        ComboTeacher.Add(new SelectListItem
                        {
                            Text = item.Name + " " + item.LastName,
                            Value = item.EmployeeId.ToString(),

                        });
                    }
                    else
                    {
                        ComboTeacher.Add(new SelectListItem
                        {
                            Text = item.Name + " " + item.LastName,
                            Value = item.EmployeeId.ToString(),
                            Selected = true
                        });
                    }
                }
                ViewBag.Teacher = ComboTeacher;


                //Schedule
                var Schedule = ScheduleModel.RequestScheduleScrollDown();
                var ComboSchedule = new List<SelectListItem>();

                ComboSchedule.Add(new SelectListItem
                {
                    Text = "Sin Horario",
                    Value = 0.ToString(),
                    Selected = true
                });



                foreach (var item in Schedule)
                {
                    ComboSchedule.Add(new SelectListItem
                    {
                        Text = item.Description,
                        Value = item.ScheduleId.ToString(),
                        Selected = true
                    });
                }
                ViewBag.Schedule = ComboSchedule;



                SetPeopleEnt setPeopleEnt = new SetPeopleEnt();

                setPeopleEnt.StudentsOutGroup = DataStudents;

                if (!init)
                {
                    var dataGroup = GroupModel.SeeGroupsByGroupId(groupIdP);
                    setPeopleEnt.GroupEnt = dataGroup;

                }


                if (!init)
                {
                    if ((int)Session["MensajePositivo"] == 1)
                    {

                        ViewBag.MsjPantallaPostivo = "El Estudiante fue asignado de manera correcta";
                    }


                    if ((int)Session["MensajeNegativo"] == 2)
                    {

                        ViewBag.MsjPantallaNegativo = "No se ha podido asignar el Estudiante";
                    }

                    if ((int)Session["MensajePositivo"] == 3)
                    {

                        ViewBag.MsjPantallaPostivo = "El Profesor fue asignado de manera correcta";
                    }


                    if ((int)Session["MensajeNegativo"] == 4)
                    {

                        ViewBag.MsjPantallaNegativo = "No se ha podido asignar el Profesor";
                    }

                    if ((int)Session["MensajeNegativo"] == 5)
                    {

                        ViewBag.MsjPantallaNegativo = "No se ha podido asignar el Estudiante porque excede el maximo de alumnos";
                    }

                }


                return View(setPeopleEnt);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }


        /*-----------------------------------------------------------------------------------------------------------*/

        [Authorize]
        [HttpGet]
        public ActionResult RemovePeople(bool init, long groupIdP)
        {

            try
            {
                var DataStudents = UserModel.SeeAllUserStudentsInGroupID(groupIdP);
                var dataGroups = GroupModel.SeeGroupsByGroupId(groupIdP);


                //Groups
                var Group = GroupModel.RequestGroupScrollDown();

                var ComboGroup = new List<SelectListItem>();




                if (init)
                {
                    ComboGroup.Add(new SelectListItem
                    {
                        Text = "Seleccionar Grupo",
                        Value = 0.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    ComboGroup.Add(new SelectListItem
                    {
                        Text = "Seleccionar Grupo",
                        Value = 0.ToString()
                    });
                }

                foreach (var item in Group)
                {
                    if (init)
                    {
                        ComboGroup.Add(new SelectListItem
                        {
                            Text = item.GroupName,
                            Value = item.GroupId.ToString(),

                        });
                    }
                    else
                    {
                        ComboGroup.Add(new SelectListItem
                        {
                            Text = item.GroupName,
                            Value = item.GroupId.ToString(),
                            Selected = true
                        });
                    }

                }
                ViewBag.Group = ComboGroup;


                //Teacher
                var Teacher = UserModel.SeeAllUserTeacher();
                var ComboTeacher = new List<SelectListItem>();


                if (init)
                {
                    ComboTeacher.Add(new SelectListItem
                    {
                        Text = "Sin Profesor",
                        Value = 0.ToString(),
                        Selected = true
                    });
                }
                else
                {


                    if (dataGroups.TeacherId == 0)
                    {
                        ComboTeacher.Add(new SelectListItem
                        {
                            Text = "Sin Profesor",
                            Value = 0.ToString(),
                            Selected = true
                        });
                    }
                }


                foreach (var item in Teacher)
                {


                    if (init)
                    {
                        ComboTeacher.Add(new SelectListItem
                        {
                            Text = item.Name + " " + item.LastName,
                            Value = item.EmployeeId.ToString(),

                        });
                    }
                    else
                    {
                        if (dataGroups.TeacherName == item.Name + " " + item.LastName)
                        {
                            ComboTeacher.Add(new SelectListItem
                            {
                                Text = item.Name + " " + item.LastName,
                                Value = item.EmployeeId.ToString(),
                                Selected = true
                            });
                        }


                    }
                }
                ViewBag.Teacher = ComboTeacher;


                //Schedule
                var Schedule = ScheduleModel.RequestScheduleScrollDown();
                var ComboSchedule = new List<SelectListItem>();

                ComboSchedule.Add(new SelectListItem
                {
                    Text = "Sin Horario",
                    Value = 0.ToString(),
                    Selected = true
                });



                foreach (var item in Schedule)
                {
                    ComboSchedule.Add(new SelectListItem
                    {
                        Text = item.Description,
                        Value = item.ScheduleId.ToString(),
                        Selected = true
                    });
                }
                ViewBag.Schedule = ComboSchedule;



                SetPeopleEnt setPeopleEnt = new SetPeopleEnt();

                setPeopleEnt.StudentsInGroup = DataStudents;

                if (!init)
                {
                    var dataGroup = GroupModel.SeeGroupsByGroupId(groupIdP);
                    setPeopleEnt.GroupEnt = dataGroup;

                }


                if (!init)
                {
                    if ((int)Session["MensajePositivo"] == 1)
                    {

                        ViewBag.MsjPantallaPostivo = "El Estudiante fue removido de manera correcta";
                    }


                    if ((int)Session["MensajeNegativo"] == 2)
                    {

                        ViewBag.MsjPantallaNegativo = "No se ha podido remover el Estudiante";
                    }

                    if ((int)Session["MensajePositivo"] == 3)
                    {

                        ViewBag.MsjPantallaPostivo = "El Profesor fue removido de manera correcta";
                    }


                    if ((int)Session["MensajeNegativo"] == 4)
                    {

                        ViewBag.MsjPantallaNegativo = "No se ha podido remover el Profesor";
                    }

                    if ((int)Session["MensajeNegativo"] == 5)
                    {

                        ViewBag.MsjPantallaNegativo = "No se ha podido remover el Estudiante porque excede el minimo de alumnos";
                    }

                    if ((int)Session["MensajeNegativo"] == 6)
                    {

                        ViewBag.MsjPantallaNegativo = "El grupo no cuenta con profesores para remover";
                    }

                }


                return View(setPeopleEnt);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }

            
        }


        /*-----------------------------------------------------------------------------------------------------------*/


        [Authorize]
        [HttpGet]
        public ActionResult ShowStudentsInGroup(long groupId)
        {
            try
            {
                var DataStudents = UserModel.SeeAllUserStudentsInGroupID(groupId);

                SetPeopleEnt setPeopleEnt = new SetPeopleEnt();

                setPeopleEnt.StudentsInGroup = DataStudents;

                return View(setPeopleEnt);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }


        /*-----------------------------------------------------------------------------------------------------------*/
        [Authorize]
        [HttpGet]
        public ActionResult CreateGroup()
        {
            try
            {
                GroupEnt ent = new GroupEnt();
                ent.CourseId = 0;
                ent.ScheduleId = 0;
                ent.TeacherId = 0;
                ent.StartDate = DateTime.Now;
                ent.EndDate = DateTime.Now;
                ent.GroupName = "El nombre del grupo es automatico";

                //Course
                var Course = CourseModel.RequestCourseScrollDown();
                var ComboCourse = new List<SelectListItem>();

                ComboCourse.Add(new SelectListItem
                {
                    Text = "Sin Curso",
                    Value = 0.ToString(),
                    Selected = true
                });

                foreach (var item in Course)
                {
                    ComboCourse.Add(new SelectListItem
                    {
                        Text = item.CourseName + " " + item.ModalityName + " " + item.LevelCourseName,
                        Value = item.CourseID.ToString(),
                        Selected = true
                    });
                }

                ComboCourse = ComboCourse.OrderBy(x => x.Text).ToList();

                ViewBag.Course = ComboCourse;


                //Teacher
                var Teacher = UserModel.SeeAllUserTeacher();
                var ComboTeacher = new List<SelectListItem>();


                ComboTeacher.Add(new SelectListItem
                {
                    Text = "Sin Profesor",
                    Value = 0.ToString(),
                    Selected = true
                });


                foreach (var item in Teacher)
                {
                    ComboTeacher.Add(new SelectListItem
                    {
                        Text = item.Name + " " + item.LastName,
                        Value = item.EmployeeId.ToString(),
                        Selected = true
                    });
                }
                ViewBag.Teacher = ComboTeacher;



                //Schedule
                var Schedule = ScheduleModel.RequestScheduleScrollDown();
                var ComboSchedule = new List<SelectListItem>();

                ComboSchedule.Add(new SelectListItem
                {
                    Text = "Sin Horario",
                    Value = 0.ToString(),
                    Selected = true
                });



                foreach (var item in Schedule)
                {
                    ComboSchedule.Add(new SelectListItem
                    {
                        Text = item.Description,
                        Value = item.ScheduleId.ToString(),
                        Selected = true
                    });
                }
                ViewBag.Schedule = ComboSchedule;



                //Status
                var Status = StateModel.RequestStatusScrollDown();
                var ComboStatus = new List<SelectListItem>();

                foreach (var item in Status)
                {
                    if (item.StatusId >= 1 && item.StatusId <= 2)
                    {
                        ComboStatus.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.StatusId.ToString(),
                            Selected = true
                        });

                    }

                }
                ViewBag.Status = ComboStatus;




                return View(ent);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }

            
        }


        [Authorize]
        [HttpGet]
        public ActionResult ShowGroups()
        {
            try
            {
                var Data = GroupModel.RequestGroupScrollDown();


                if ((int)Session["MensajePositivo"] == 1)
                {

                    ViewBag.MsjPantallaPostivo = "El Grupo fue creado de manera correcta";
                }


                if ((int)Session["MensajeNegativo"] == 2)
                {

                    ViewBag.MsjPantallaNegativo = "No se ha podido crear Grupo";
                }


                if ((int)Session["MensajePositivo"] == 3)
                {

                    ViewBag.MsjPantallaPostivo = "El Grupo fue modificado de manera correcta";
                }


                if ((int)Session["MensajeNegativo"] == 4)
                {

                    ViewBag.MsjPantallaNegativo = "No se ha podido modificar la informacion del Grupo";
                }

                return View(Data);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditGroup(long i)
        {
            try
            {
                var data = GroupModel.SeeGroupsByGroupId(i);


                //Course
                var Course = CourseModel.RequestCourseScrollDown();
                var ComboCourse = new List<SelectListItem>();

                foreach (var item in Course)
                {
                    ComboCourse.Add(new SelectListItem
                    {
                        Text = item.CourseName + " " + item.ModalityName + " " + item.LevelCourseName,
                        Value = item.CourseID.ToString(),
                        Selected = true
                    });
                }
                ViewBag.Course = ComboCourse;


                //Teacher
                var Teacher = UserModel.SeeAllUserTeacher();
                var ComboTeacher = new List<SelectListItem>();

                foreach (var item in Teacher)
                {
                    ComboTeacher.Add(new SelectListItem
                    {
                        Text = item.Name + " " + item.LastName,
                        Value = item.EmployeeId.ToString(),
                        Selected = true
                    });
                }
                ViewBag.Teacher = ComboTeacher;



                //Schedule
                var Schedule = ScheduleModel.RequestScheduleScrollDown();
                var ComboSchedule = new List<SelectListItem>();
                foreach (var item in Schedule)
                {
                    ComboSchedule.Add(new SelectListItem
                    {
                        Text = item.Description,
                        Value = item.ScheduleId.ToString(),
                        Selected = true
                    });
                }
                ViewBag.Schedule = ComboSchedule;



                //Status
                var Status = StateModel.RequestStatusScrollDown();
                var ComboStatus = new List<SelectListItem>();
                foreach (var item in Status)
                {
                    if (item.StatusId >= 1 && item.StatusId <= 2)
                    {
                        ComboStatus.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.StatusId.ToString(),
                            Selected = true
                        });

                    }

                }
                ViewBag.Status = ComboStatus;



                return View(data);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }

            
        }


        [Authorize]
        [HttpPost]
        public ActionResult SendInfoEditGroup(GroupEnt groupEnt)
        {


            try
            {


                var resp = GroupModel.EditGroups(groupEnt);

                if (resp > 0)
                {
                    Session["MensajePositivo"] = 3;
                }
                else
                {
                    Session["MensajeNegativo"] = 4;
                }

                return RedirectToAction("EditGroup", "Group", new { i = groupEnt.GroupId });
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
        }


        [Authorize]
        [HttpPost]
        public ActionResult SendInfoCreateGroup(GroupEnt groupEnt)
        {


            try
            {


                var resp = GroupModel.CreateGroup(groupEnt);

                if (resp > 0)
                {
                    Session["MensajePositivo"] = 1;
                }
                else
                {
                    Session["MensajeNegativo"] = 2;
                }

                return RedirectToAction("CreateGroup", "Group");
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return RedirectToAction("ErrorAdministration", "Error");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AssignGroupToStudent(long groupId, string personalId)
        {


            try
            {

                GroupEnt groupEnt = GroupModel.SeeGroupsByGroupId(groupId);

                if ((groupEnt.StudentsNumber + 1) > groupEnt.MaxStudentsNumber)
                {
                    Session["MensajeNegativo"] = 5;
                }
                else
                {
                    var UserEntResp = UserModel.RequestUserByPersonalID(personalId);

                    var resp = GroupModel.AssignGroupToStudent(groupId, UserEntResp.UserId);


                    groupEnt.StudentsNumber++;

                    var resp2 = GroupModel.EditGroups(groupEnt);

                    if (resp > 0 && resp2 > 0)
                    {
                        Session["MensajePositivo"] = 1;
                    }
                    else
                    {
                        Session["MensajeNegativo"] = 2;
                    }

                }





                return RedirectToAction("SetPeople", "Group", new { init = false, groupIdP = groupId });
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return RedirectToAction("ErrorAdministration", "Error");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AssignTeacherToGroup(long groupId, long teacherId)
        {


            try
            {


                var resp = GroupModel.AssignTeacherToGroup(groupId, teacherId);

                if (resp > 0)
                {
                    Session["MensajePositivo"] = 3;
                }
                else
                {
                    Session["MensajeNegativo"] = 4;
                }


                return RedirectToAction("SetPeople", "Group", new { init = false, groupIdP = groupId });
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return RedirectToAction("ErrorAdministration", "Error");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult RemoveStudentFromGroup(long groupId, string personalId)
        {


            try
            {

                GroupEnt groupEnt = GroupModel.SeeGroupsByGroupId(groupId);

                if ((groupEnt.StudentsNumber - 1) < 0)
                {
                    Session["MensajeNegativo"] = 6;
                }
                else
                {
                    var UserEntResp = UserModel.RequestUserByPersonalID(personalId);

                    var resp = GroupModel.RemoveStudentFromGroup(groupId, UserEntResp.UserId);



                    groupEnt.StudentsNumber--;

                    var resp2 = GroupModel.EditGroups(groupEnt);


                    if (resp > 0 && resp2 > 0)
                    {
                        Session["MensajePositivo"] = 1;
                    }
                    else
                    {
                        Session["MensajeNegativo"] = 2;
                    }
                }




                return RedirectToAction("RemovePeople", "Group", new { init = false, groupIdP = groupId });
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return RedirectToAction("ErrorAdministration", "Error");
            }
        }


        [Authorize]
        [HttpPost]
        public ActionResult RemoveTeacherFromGroup(long groupId)
        {


            try
            {
                var data = GroupModel.SeeGroupsByGroupId(groupId);
                if (data.TeacherName.Equals("Sin Profesor"))
                {

                    Session["MensajeNegativo"] = 6;
                }
                else
                {
                    var resp = GroupModel.RemoveTeacherFromGroup(groupId);

                    if (resp > 0)
                    {
                        Session["MensajePositivo"] = 3;
                    }
                    else
                    {
                        Session["MensajeNegativo"] = 4;
                    }

                }




                return RedirectToAction("RemovePeople", "Group", new { init = false, groupIdP = groupId });
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return RedirectToAction("ErrorAdministration", "Error");
            }
        }



        [HttpGet]
        public JsonResult cleanSessionMessage()
        {


            try
            {
                Session["MensajePositivo"] = 0;
                Session["MensajeNegativo"] = 0;



                return Json(new { success = true, message = "Sesión limpiada correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return Json(new { success = false, message = "Error al limpiar la sesión." }, JsonRequestBehavior.AllowGet);
            }
        }



    }


}
