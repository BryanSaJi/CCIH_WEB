
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
    public class RoleController : Controller
    {
        RoleModel model = new RoleModel();


        [HttpGet]
        public ActionResult ListRoles()
        {
            var data = model.RequestRoles();
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


        [HttpPost]
        public ActionResult CreateRole(RoleEnt ent)
        {
            try
            {

                var resp = model.CreateRole(ent);

                if (resp > 0)
                    return RedirectToAction("ListRoles", "Role");
                else
                {
                    ViewBag.Msj = "No se ha podido registrar su información";
                    return View("ListRoles");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return View("Error");
            }
        }



        [HttpGet]
        public ActionResult RegisterRole()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EditRole(long i)
        {
            Session["MensajeNegativo"] = 0;
            Session["MensajePositivo"] = 0;
            var data = model.RequestRole(i);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditRole(RoleEnt ent)
        {
            Session["MensajeNegativo"] = 0;
            Session["MensajePositivo"] = 0;
            try
            {

                var resp = model.EditRole(ent);

                if (resp > 0)
                {
                    Session["MensajePositivo"] = 1;
                    return RedirectToAction("ListRoles");
                }
                        
                else
                {
                    Session["MensajeNegativo"] = 1;
                    return View("ListRoles");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult DeleteRole(long i)
        {
            try
            {

                var resp = model.DeleteRole(i);

                if (resp > 0)
                    return RedirectToAction("ListRoles", "Rol");
                else
                {
                    ViewBag.Msj = "No se ha podido eliminar el Rol";
                    return View("ListRoles");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return View("Error");
            }
        }



        [HttpGet]
        public List<RoleEnt> ListRolesScrollDown()
        {
            var data = model.RequestRolesScrollDown();
            return data;
        }

    }
}
