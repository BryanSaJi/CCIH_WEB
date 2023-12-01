using CCIH.Entities;
using CCIH.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace CCIH.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        UserModel model = new UserModel();
        RoleModel modelRole = new RoleModel();
        StateModel modelState = new StateModel();
        TeacherModel modelTeacher = new TeacherModel();
 
        [HttpGet]
        public ActionResult Index()
        {
            var teachers = modelTeacher.MarkHistory();

            return View(teachers);

        }

        [HttpGet]
        public ActionResult AssingTeacher()
        {
            return View();
        }



     
        public ActionResult RequestTeacher()
        {
            var teachers = modelTeacher.RequestTeacher();
            
                return View(teachers);
        }

        [HttpPost]
        public ActionResult TimeMarkTeacher(long i)
        {
            int user = int.Parse(Session["IdUser"].ToString());

            TeacherEnt ent = new TeacherEnt();

            if (i > 0)
            {
                if (i == 1)
                {
                    ent.Office_SH_ID = ent.Office_SH_ID;
                    ent.EntryTime = DateTime.Now;
                    ent.UserId = user;

                    // Obtener el off ID 
                    int office_SH_ID = modelTeacher.EntryMark(ent);

                    // Guardar el off ID 
                    Session["Office_SH_ID"] = office_SH_ID;
                }
                else if (i == 2)
                {
            
                    ent.Office_SH_ID = (int)Session["Office_SH_ID"];
                    ent.ExitTime = DateTime.Now;
                    modelTeacher.ExitMark(ent);

                      
                    
                }
            }

            return View();
        }



        [HttpGet]
        public ActionResult TimeMarkTeacher()
        {
           return View();
        }




        public ActionResult MarkHistory()
        {
            var teachers = modelTeacher.MarkHistory();

            return View(teachers);
        }


       [HttpGet]
        public ActionResult AllHours()
        {

            var totalHours = modelTeacher.TotalWorkHours();
            return View(totalHours);



        }

        //[HttpPost]
        //public ActionResult SumHours(DateTime EntryTime, DateTime ExitExit)
        //{
        //    var teachers = modelTeacher.TotalWorkHours().Where(t => t.EntryTime >= EntryTime && t.ExitTime <= ExitExit).ToList();
        //    decimal sumTotal = teachers.Sum(t => t.TotalWorkHours);

        //    ViewBag.TotalWorkHours = sumTotal;
        //    return RedirectToAction("AllHours", "Teacher");

        //}

    }




}


