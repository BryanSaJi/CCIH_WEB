using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class RolController : Controller
    {
        RolModel model = new RolModel();
        // GET: Rol
        [HttpGet]
        public ActionResult ListarRoles()
        {
            var datos = model.ConsultarRoles();
            return View(datos);
        }


        [HttpPost]
        public ActionResult RegistrarRol(RolEnt entidad)
        {
            try
            {

                var resp = model.RegistrarRol(entidad);

                if (resp > 0)
                    return RedirectToAction("ListarRoles", "Rol");
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido registrar su información";
                    return View("ListarRoles");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }



        [HttpGet]
        public ActionResult RegistrarRol()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EditarRol(long i)
        {
            var datos = model.ConsultarRol(i);
            datos.IdUsuario = long.Parse(Session["IdUsuario"].ToString());
            return View(datos);
        }
        [HttpPost]
        public ActionResult EditarRol(RolEnt ent)
        {
            try
            {

                var resp = model.ModificarRol(ent);

                if (resp > 0)
                    return RedirectToAction("ListarRoles", "Rol");
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido registrar su información";
                    return View("ListarRoles");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult EliminarRol(long i)
        {
            try
            {

                var resp = model.EliminarRol(i);

                if (resp > 0)
                    return RedirectToAction("ListarRoles", "Rol");
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido eliminar el Rol";
                    return View("ListarRoles");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }



        [HttpGet]
        public List<RolEnt> ListarRolesScrollDown()
        {
            var datos = model.ConsultarRolesListarRolesScrollDown();
            return datos;
        }

    }
}
