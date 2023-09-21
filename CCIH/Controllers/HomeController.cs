using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace CCIH.Controllers
{
    public class HomeController : Controller
    {
        UsuarioModel model = new UsuarioModel();
        MatriculaModel modelMatricula = new MatriculaModel();
        CursosModel modelCurso = new CursosModel();
        ModalidadModel modelModalidad = new ModalidadModel();
        NivelModel modelNivel = new NivelModel();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Acerca()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult Cursos()
        {
            return View();
        }

        public ActionResult Profesores()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginReset()
        {
            return View();
        }

        public ActionResult Ing_Intensivo_P()
        {
            return View();
        }

        public ActionResult Ing_Intensivo_V()
        {
            return View();
        }

        public ActionResult Ing_Semi_Intensivo_P()
        {
            return View();
        }

        public ActionResult Ing_Semi_Intensivo_V()
        {
            return View();
        }

        public ActionResult Ing_Niños_V()
        {
            return View();
        }

        public ActionResult Portu_Semi_Intensivo_V()
        {
            return View();
        }

        public ActionResult PreMatricular()
        {
            //Crusos
            var crusos = modelCurso.ConsultarCrusosListarRolesScrollDown();
            var ComboCruso = new List<SelectListItem>();
            foreach (var item in crusos)
            {
                ComboCruso.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.IdCurso.ToString()
                });
            }
            //Modalidad
            var modalidad = modelModalidad.ConsultarModalidadListarRolesScrollDown();
            var ComboModalidad = new List<SelectListItem>();
            foreach (var item in modalidad)
            {
                ComboModalidad.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.IdModalidad.ToString()
                });
            }
            //Nivel
            var nivel = modelNivel.ConsultarNivelListarRolesScrollDown();
            var ComboNivel = new List<SelectListItem>();
            foreach (var item in nivel)
            {
                ComboNivel.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.IdNivelCurso.ToString()
                });
            }
            ViewBag.Nivel = ComboNivel;
            ViewBag.Modalidad = ComboModalidad;
            ViewBag.Cruso = ComboCruso;
            return View();
        }

        public ActionResult PreMatricularCurso(PreMatriculaEnt entidad)
        {
            try
            {
                entidad.FechaPreMatricula = DateTime.Now;
                entidad.IdEstatus = 1;
                var resp = modelMatricula.PreMatricularCurso(entidad);

                if (resp > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido registrar su información";
                    return View("PreMatricular");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }
        [HttpPost]
        public ActionResult IniciarSesion(UsuarioEnt entidad)
        {
            //Programacion
            try
            {
                entidad.PwUsuario = model.Encrypt(entidad.PwUsuario);
                var resp = model.IniciarSesion(entidad);

                if (resp != null)
                {
                   
                    Session["IdUsuario"] = resp.IdUsuario.ToString();
                    Session["IdRolUsuario"] = resp.IdRol;
                    Session["[Usuario]"] = resp.Usuario;
                    Session["[NombreRol]"] = resp.NombreRol;
                    Session["TokenUsuario"] = resp.Token;

                    //var cliente = model.ConsultarCliente(Session["IdUsuario"]);
                    return RedirectToAction("Inicio", "Administracion");
                }
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido validar su información";
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                return View("Login");
            }
            
        }
     

            public ActionResult ContactoConsulta(ContactoEnt Entidad)
        {
            //Programacion envio correo a institucion

            return RedirectToAction("", "");
        }

        public ActionResult RestablecerUsuario(UsuarioEnt Entidad)
        {
            //Programacion restablecer contraseña y enviar al correo

            return RedirectToAction("", "");
        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }


    }

}