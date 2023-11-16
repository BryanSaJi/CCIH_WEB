using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Teachers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateTeacher()
        {
            return View();
        }

        public ActionResult RequestTeacher()
        {
            return View();
        }

        public ActionResult CheckInTeacher()
        {
            return View();
        }
        public ActionResult CoursesTeacher()
        {
            return View();
        }
    }
}