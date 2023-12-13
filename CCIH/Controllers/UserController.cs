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
using System.Globalization;

namespace CCIH.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserModel model = new UserModel();
        RoleModel modelRole = new RoleModel();
        StateModel modelState = new StateModel();
        IdentificationsModel modelIdentifications = new IdentificationsModel();



        [Authorize]
        public ActionResult Index()
        {
            var data = model.RequestUsers();


            foreach (var item in data)
            {
                var Status = modelState.RequestStatusScrollDown();
                var rol = modelRole.RequestRoles();
                foreach (var item2 in Status)
                {
                    if (item.StatusId == item2.StatusId)
                    {
                        item.StatusName = item2.Name;
                    }
                }
                foreach (var item2 in rol)
                {
                    if (item.IdRol == item2.IdRol)
                    {
                        item.RolName = item2.Name;
                    }
                }
            }


            data = data.OrderByDescending(x => x.LastActivity).ToList();
            return View(data);
        }


        [HttpPost]
        public ActionResult RegisterUser(UserEnt ent)
        {
            ent.StatusId = 1;

            try
            {

                var resp = model.CreateUser(ent);

                if (resp > 0)
                {
                    if (ent.IdRol == 3)
                    {
                        Session["CedulaCliente"] = ent.PersonalID;
                        return RedirectToAction("CreateRegister", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    return RedirectToAction("Customer", "Admin");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

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

            var Identifications = modelIdentifications.RequestIdentificationsScrollDown();
            var ComboIdentifications = new List<SelectListItem>();
            foreach (var item in Identifications)
            {
                ComboIdentifications.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdentificationsId.ToString()
                });
            }
            ViewBag.Identifications = ComboIdentifications;

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(UserEnt ent)
        {
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
                        return RedirectToAction("ChangePassword");
                    }
                    return RedirectToAction("ChangePassword");
                }
                return RedirectToAction("ChangePassword");
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
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
        public ActionResult EditUser(long i)
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

            var Identifications = modelIdentifications.RequestIdentificationsScrollDown();
            var ComboIdentifications = new List<SelectListItem>();
            foreach (var item in Identifications)
            {
                ComboIdentifications.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdentificationsId.ToString()
                });
            }
            ViewBag.Identifications = ComboIdentifications;

            if (TempData.ContainsKey("RespuestaPositivaEditarUsuario"))
            {
                ViewBag.MsjPantallaPositivo = "Informacion del Usuario actualizada.";
                TempData.Remove("RespuestaPositivaEditarUsuario");
            }
            if (TempData.ContainsKey("RespuestaNegativaEditarUsuario"))
            {
                ViewBag.MsjPantallaNegativo = "No se pudo actualizar el usuario.";
                TempData.Remove("RespuestaNegativaEditarUsuario");
            }

            return View(data);
        }


        [HttpPost]
        public ActionResult EditUser(UserEnt ent)
        {
            try
            {

                var resp = model.EditUser(ent);

                if (resp > 0)
                {
                    TempData["RespuestaPositivaEditarUsuario"] = true;
                    return RedirectToAction("EditUser", "User", new { i = ent.UserId });
                }
                else
                {
                    TempData["RespuestaNegativaEditarUsuario"] = true;
                    return RedirectToAction("EditUser", "User", new { i = ent.UserId });
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return RedirectToAction("ErrorAdministration", "Error");
            }
        }


    }
}