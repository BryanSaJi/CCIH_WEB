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


        // GET: Teachers
        public ActionResult Index()
        {
            return View();

        }


        public ActionResult AssingTeacher()
        {
            return View();
        }

        public ActionResult RequestTeacher()
        {
            var data = model.RequestUsers();

            foreach (var item in data)
            {
                var Status = modelState.RequestStatusScrollDown();
                foreach (var item2 in Status)
                {
                    if (item.StatusId == item2.StatusId)
                    {
                        item.StatusName = item2.Name;
                    }
                }
            }
            if ((int)Session["MensajePositivo"] == 1)
            {
                ViewBag.MsjPantallaPostivo = "Operacion Exitosa";
            }
            if ((int)Session["MensajeNegativo"] == 1)
            {
                ViewBag.MsjPantallaNegativo = "Operacion sin Exito";
            }
            return View(data);
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