using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class CursosController : Controller
    {
        CursosModel modelCurso = new CursosModel();


        public ActionResult Index()
        {
            var datos = modelCurso.ConsultarCrusosListarRolesScrollDown();
            return View(datos);
        }

    }
}