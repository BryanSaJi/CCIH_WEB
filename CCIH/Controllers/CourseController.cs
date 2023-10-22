using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class CourseController : Controller
    {

        CourseModel modelCourse = new CourseModel();


        public ActionResult Index()
        {
            var data = modelCourse.RequestCourseScrollDown();
            return View(data);
        }

    }
}