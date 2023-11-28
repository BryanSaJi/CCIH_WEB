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
    public class GroupController : Controller
    {

        GroupModel GroupModel = new GroupModel();
        StateModel StateModel = new StateModel();
        CourseModel CourseModel = new CourseModel();
        UserModel UserModel = new UserModel();
        ScheduleModel ScheduleModel = new ScheduleModel();

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Authorize]
        public ActionResult ShowGroups()
        {
            var Data = GroupModel.RequestGroupScrollDown();
            return View(Data);
        }


        [HttpGet]
        [Authorize]
        public ActionResult EditGroup(long i)
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
                    Value = item.CourseID.ToString()
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
                    Value = item.EmployeeId.ToString()
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
                    Value = item.ScheduleId.ToString()
                });
            }
            ViewBag.Schedule = ComboSchedule;



            //Status
            var Status = StateModel.RequestStatusScrollDown();
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

            if (TempData.ContainsKey("RespuestaPositivaGrupo"))
            {
                ViewBag.MsjPantallaPositivo = "Operacion Exitosa, Informacion del Grupo guardada.";
                TempData.Remove("RespuestaPositivaGrupo");
            }
            if (TempData.ContainsKey("RespuestaNegativoGrupo"))
            {
                ViewBag.MsjPantallaNegativo = "No fue posible actualizar la informacion del grupo.";
                TempData.Remove("RespuestaNegativoGrupo");
            }

            return View(data);
        }



        [HttpPost]
        [Authorize]
        public ActionResult SendInfoEditGroup(GroupEnt groupEnt)
        {
            

            try
            {

                var resp = GroupModel.EditGroups(groupEnt);

                if (resp > 0)
                {
                    TempData["RespuestaPositivaGrupo"] = true;
                }
                else
                {
                    TempData["RespuestaNegativoGrupo"] = true;
                }

                return RedirectToAction("EditGroup", "Group", new { i = groupEnt.GroupId });
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


    }


}
