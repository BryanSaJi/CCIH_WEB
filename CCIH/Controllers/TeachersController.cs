using CCIH.Entities;
using CCIH.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
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
                ent.Name = "CheckIN";
                ent.TimeMarkID = 1;
                ent.UserId = user;

                }
                else if (i == 2)
              {
                ent.Name = "CheckOUT";
                ent.TimeMarkID = 2;
                ent.UserId = user;
                }

             var data = modelTeacher.InsertOFF(ent);
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




    }
}
