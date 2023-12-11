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

            if ((int)Session["MensajePositivo"] == 1)
            {
                ViewBag.MsjPantallaPostivo = "Operacion Exitosa";
            }
            if ((int)Session["MensajeNegativo"] == 1)
            {
                ViewBag.MsjPantallaNegativo = "Operacion sin Exito";
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
                        Session["MensajePositivo"] = 1;
                        return RedirectToAction("CreateRegister", "Admin");
                    }
                    else
                    {
                        Session["MensajePositivo"] = 1;
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    Session["MensajeNegativo"] = 4;
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
                var exept = ex.Message;

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

            if ((int)Session["MensajePositivo"] == 1)
            {
                ViewBag.MsjPantallaPostivo = "El usuario fue modificado de manera correcta";
            }


            if ((int)Session["MensajeNegativo"] == 2)
            {
                ViewBag.MsjPantallaNegativo = "No se ha podido modificar la informacion del perfil";
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
                        return RedirectToAction("EditUser", "User", new { i = ent.UserId });
                    }
                    else
                    {
                        return RedirectToAction("EditUser", "User", new { i = ent.UserId }); 
                    }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;

                return View("Error");
            }
        }


    }
}