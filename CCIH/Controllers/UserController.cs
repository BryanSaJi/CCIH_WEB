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
        RoleModel roleModel = new RoleModel();
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        StateModel modelState = new StateModel();

        // GET: Usuario
        public ActionResult Index()
        {
            var data = model.RequetUsers();
            return View(data);
        }


        [HttpPost]
        public ActionResult RegisterUser(UserCustomEnt ent)
        {
            try
            {

                var resp = model.RegisterUser(ent);

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
            var roles = roleModel.RequetRoles();
            var ddRoles = new List<SelectListItem>();
            foreach (var item in roles)
            {
                ddRoles.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdRole.ToString()
                });
            }
            ViewBag.Combo = ddRoles;
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePwEnt ent)
        {
            try
            {
                ent.IdUser = long.Parse(Session["IdUser"].ToString());
                ent.PWNow = model.Encrypt(ent.PWNow);
                ent.PwNew = model.Encrypt(ent.PwNew);
                ent.ConfirmPw = model.Encrypt(ent.ConfirmPw);
                var resp = model.ChangePassword(ent);

                if (ent.PwNew == ent.ConfirmPw && resp > 0)
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
            var data = model.RequetUser(i);
            var roles = roleModel.RequetRoles();

            var ddRoles = new List<SelectListItem>();

            // QR Code

            String Token = Session["TokenUser"].ToString();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Token, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            ImageConverter converter = new ImageConverter();

            byte[] QRcode = (byte[])converter.ConvertTo(qrCodeImage, typeof(byte[]));

            data.QRcode = QRcode;


            var State = modelState.RequestStatusScrollDown();
            var ComboState = new List<SelectListItem>();
            foreach (var item in State)
            {
                ComboState.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdState.ToString()
                });
            }
            ViewBag.State = ComboState;



            foreach (var item in roles)
            {
                ddRoles.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdRole.ToString()
                });
            }

            ViewBag.Combo = ddRoles;

            return View(data);
        }



        [HttpPost]
        public ActionResult EditUser(UserCustomEnt ent)
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