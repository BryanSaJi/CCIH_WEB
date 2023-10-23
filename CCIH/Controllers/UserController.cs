using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;
using System.Drawing;

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
            var data = model.RequestUser();
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
                    Value = item.IdRole.ToString()
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
                    Value = item.IdRole.ToString()
                });
            }
            ViewBag.Rol = ComboRol;

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordEnt ent)
        {
            try
            {
                ent.UserID = long.Parse(Session["IdUser"].ToString());
                ent.CurrentPW = model.Encrypt(ent.CurrentPW);
                ent.NewPw = model.Encrypt(ent.NewPw);
                ent.ConfirmPw = model.Encrypt(ent.ConfirmPw);
                var resp = model.ChangePassword(ent);

                if (ent.NewPw == ent.ConfirmPw && resp > 0)
                    return RedirectToAction("Index", "Home");
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
        public ActionResult ChangePassword()
        {
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
                    Value = item.IdRole.ToString()
                });
            }
            ViewBag.Rol = ComboRol;

            return View(data);
        }


        [HttpPost]
        public ActionResult EditUser(UserEnt ent)
        {
            try
            {

                var resp = model.Edituser(ent);

                if (resp > 0)
                    return RedirectToAction("Index", "User");
                else
                {
                    ViewBag.Msj = "No se ha podido registrar su información";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult DeleteUser(long i)
        {
            try
            {

                var resp = model.DeleteUser(i);

                if (resp > 0)
                    return RedirectToAction("Index", "User");
                else
                {
                    ViewBag.Msj = "No se ha podido eliminar el usuario";
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