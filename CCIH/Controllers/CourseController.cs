using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CCIH.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {

        CourseModel modelCourse = new CourseModel();


        public ActionResult Index()
        {
            var data = modelCourse.RequestCourseScrollDown();
            return View(data);
        }

        [AllowAnonymous]
        public ActionResult ObtenerCursosDesdeBaseDeDatos(string name)
        {

            var list = modelCourse.SeeCoursesFiltered(name).ToList();

            // Convertir la lista de cursos a JSON
            var jsonCursos = Json(list, JsonRequestBehavior.AllowGet);

            // Devolver los datos JSON
            return jsonCursos;
        }

        

    }
}