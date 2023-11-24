using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();

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


        public ActionResult TimeMarkTeacher()
        {
            return View();
        }

    }
}