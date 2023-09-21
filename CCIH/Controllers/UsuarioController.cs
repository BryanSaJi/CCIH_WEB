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
    public class UsuarioController : Controller
    {
        UsuarioModel model = new UsuarioModel();
        RolModel rolModel = new RolModel();
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        EstatusModel modelEstatus = new EstatusModel();

        // GET: Usuario
        public ActionResult Index()
        {
            var datos = model.ConsultarUsuarios();
            return View(datos);
        }


        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioClienteEnt entidad)
        {
            try
            {

                var resp = model.RegistrarUsuario(entidad);

                if (resp > 0)
                    return RedirectToAction("Index", "Usuario");
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido registrar su información";
                    return View("Registro");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public ActionResult RegistrarUsuario()
        {
            var roles = rolModel.ConsultarRoles();
            var ddRoles = new List<SelectListItem>();
            foreach (var item in roles)
            {
                ddRoles.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.IdRol.ToString()
                });
            }
            ViewBag.Combo = ddRoles;
            return View();
        }

        [HttpPost]
        public ActionResult CambiarContrasenna(CambiarContrasennaEnt entidad)
        {
            try
            {
                entidad.IdUsuario = long.Parse(Session["IdUsuario"].ToString());
                entidad.PWActual = model.Encrypt(entidad.PWActual);
                entidad.PwNuevo = model.Encrypt(entidad.PwNuevo);
                entidad.ConfirmPw = model.Encrypt(entidad.ConfirmPw);
                var resp = model.CambiarContrasenna(entidad);

                if (entidad.PwNuevo == entidad.ConfirmPw && resp > 0)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido registrar su información";
                    return View("Registro");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public ActionResult CambiarContraseña()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditarUsuario(long i)
        {
            var datos = model.ConsultarUsuario(i);
            var roles = rolModel.ConsultarRoles();

            var ddRoles = new List<SelectListItem>();

            // QR Code

            String Token = Session["TokenUsuario"].ToString();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Token, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            ImageConverter converter = new ImageConverter();

            byte[] QRcode  = (byte[])converter.ConvertTo(qrCodeImage, typeof(byte[]));

            datos.QRcode = QRcode;


            var estatus = modelEstatus.ConsultarEstatusListarRolesScrollDown();
            var ComboEstatus = new List<SelectListItem>();
            foreach (var item in estatus)
            {
                ComboEstatus.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.IdEstatus.ToString()
                });
            }
            ViewBag.Estatus = ComboEstatus;



            foreach (var item in roles)
            {
                ddRoles.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.IdRol.ToString()
                });
            }

            ViewBag.Combo = ddRoles;

            return View(datos);
        }



        [HttpPost]
        public ActionResult EditaUsuario(UsuarioClienteEnt entidad)
        {
            try
            {

                var resp = model.EditarUsuario(entidad);

                if (resp > 0)
                    return RedirectToAction("Index", "Usuario");
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido registrar su información";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult EliminarUsuario(long i)
        {
            try
            {

                var resp = model.EliminarUsuario(i);

                if (resp > 0)
                    return RedirectToAction("Index", "Usuario");
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido eliminar el usuario";
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