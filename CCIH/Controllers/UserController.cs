using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;
using System.Drawing;
using System.Web.Security;

namespace CCIH.Controllers
{
    public class UserController : Controller
    {
        UserModel model = new UserModel();
        RoleModel modelRole = new RoleModel();
        StateModel modelState = new StateModel();
        

        // GET: Usuario
        public ActionResult Index()
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


        [HttpPost]
        public ActionResult RegisterUser(UserEnt ent)
        {
            //Estatus
            var Status = modelState.RequestStatusScrollDown();
            var ComboStatus = new List<SelectListItem>();
            foreach (var item in Status)
            {
                ComboStatus.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.StatusId.ToString()
                });
            }
            ViewBag.Status = ComboStatus;

            //Roles
            var rol = modelRole.RequestRolesScrollDown();
            var ComboRol = new List<SelectListItem>();
            foreach (var item in rol)
            {
                ComboRol.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdRol.ToString()
                });
            }
            ViewBag.Rol = ComboRol;

            try
            {

                var resp = model.CreateUser(ent);

                if (resp > 0)
                    return RedirectToAction("Index", "User");
                else
                {
                    ViewBag.Msj = "No se ha podido registrar su información";
                    return View("RegisterUser");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public ActionResult RegisterUser()
        {
            //Estatus
            var Status = modelState.RequestStatusScrollDown();
            var ComboStatus = new List<SelectListItem>();
            foreach (var item in Status)
            {
                ComboStatus.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.StatusId.ToString()
                });
            }
            ViewBag.Status = ComboStatus;

            //Roles
            var rol = modelRole.RequestRolesScrollDown();
            var ComboRol = new List<SelectListItem>();
            foreach (var item in rol)
            {
                ComboRol.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdRol.ToString()
                });
            }
            ViewBag.Rol = ComboRol;

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(UserEnt ent)
        {
            Session["MensajeNegativo"] = 0;
            Session["MensajePositivo"] = 0;
            try
            {
                ent.UserId = long.Parse(Session["IdUser"].ToString());
                ent.UserPw = model.Encrypt(ent.UserPw);
                ent.NewUserPw = model.Encrypt(ent.NewUserPw);
                ent.ConfirmPw = model.Encrypt(ent.ConfirmPw);
                

                if (ent.NewUserPw == ent.ConfirmPw)
                {
                    if (ent.UserPw != ent.NewUserPw)
                    {
                        var resp = model.ChangePassword(ent);
                        Session["MensajePositivo"] = 1;
                        return RedirectToAction("ChangePassword");
                    }
                    Session["MensajeNegativo"] = 2;
                    return RedirectToAction("ChangePassword");
                }
                Session["MensajeNegativo"] = 3;
                return RedirectToAction("ChangePassword");
            }
            catch (Exception ex)
            {
                Session["MensajeNegativo"] = 1;
                return RedirectToAction("ChangePassword");
            }
        }
        public ActionResult ChangePassword()
        {
            if ((int)Session["MensajePositivo"] == 1)
            {
                ViewBag.MsjPantallaPostivo = "Operacion Exitosa";
            }


            if ((int)Session["MensajeNegativo"] == 1)
            {
                ViewBag.MsjPantallaNegativo = "Operacion sin Exito";
            }
            if ((int)Session["MensajeNegativo"] == 2)
            {
                ViewBag.MsjPantallaNegativo = "La contraseña nueva no puede ser igual a la actual";
            }
            if ((int)Session["MensajeNegativo"] == 3)
            {
                ViewBag.MsjPantallaNegativo = "La contraseña nueva y confirmacion no son iguales";
            }
            return View();
        }


        [HttpGet]
        public ActionResult EditUser(long i,bool msj)
        {
            var data = model.RequestUser(i);

            //Estatus
            var Status = modelState.RequestStatusScrollDown();
            var ComboStatus = new List<SelectListItem>();
            foreach (var item in Status)
            {
                ComboStatus.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.StatusId.ToString()
                });
            }
            ViewBag.Status = ComboStatus;

            //Roles
            var rol = modelRole.RequestRolesScrollDown();
            var ComboRol = new List<SelectListItem>();
            foreach (var item in rol)
            {
                ComboRol.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdRol.ToString()
                });
            }
            ViewBag.Rol = ComboRol;

            // Send ViewBack
            if (msj) {
                ViewBag.MsjSucces = "El Perfil fue modificado exitosamente";
            }

            return View(data);
        }


        [HttpPost]
        public ActionResult EditUser(UserEnt ent)
        {
            try
            {

                var resp = model.Edituser(ent);

                if (resp > 0)
                    if (ent.IdRol == 3)
                    {
                        //Session["MensajePositivo"] = 1;
                        
                        
                        return RedirectToAction("EditUser", "User", new { i = ent.UserId, msj = true });
                    }
                    else
                    {
                        //Session["MensajePositivo"] = 1;
                        
                        
                        return RedirectToAction("EditUser", "User", new { i = ent.UserId, msj = true }); 
                    }
                else
                {
                    ViewBag.MsjError = "No se ha podido modificar la informacion del perfil";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


    }
}