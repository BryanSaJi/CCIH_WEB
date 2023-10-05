﻿using CCIH.Entities;
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
        UserModel model = new UserModel();
        RegistrationModel modelRegitration = new RegistrationModel();
        CourseModel modelCourse = new CourseModel();
        ModalityModel modelModality = new ModalityModel();
        LevelModel modelLevel = new LevelModel();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Course()
        {
            return View();
        }

        public ActionResult Teachers()
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

        public ActionResult Eng_Intensive_P()
        {
            return View();
        }

        public ActionResult Eng_Intensive_V()
        {
            return View();
        }

        public ActionResult Eng_Semi_Intensive_P()
        {
            return View();
        }

        public ActionResult Eng_Semi_Intensive_V()
        {
            return View();
        }

        public ActionResult Eng_Kids_V()
        {
            return View();
        }

        public ActionResult Portu_Semi_Intensive_V()
        {
            return View();
        }

        public ActionResult PreRegister()
        {
            //Crusos
            var course = modelCourse.ConsultCourseListRolesScrollDown();
            var ComboCourse = new List<SelectListItem>();
            foreach (var item in course)
            {
                ComboCourse.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdCourse.ToString()
                });
            }
            //Modalidad
            var Modality = modelModality.ConsultModalityListRolesScrollDown();
            var ComboModality = new List<SelectListItem>();
            foreach (var item in Modality)
            {
                ComboModality.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdModality.ToString()
                });
            }

            //level
            var level = modelLevel.ConsultLevelListRolesScrollDown();
            var Combolevel = new List<SelectListItem>();
            foreach (var item in level)
            {
                Combolevel.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.IdLevelCourse.ToString()
                });
            }
            ViewBag.level = Combolevel;
            ViewBag.Modalidad = ComboModality;
            ViewBag.level = Combolevel;
            return View();
        }

        public ActionResult PreRegistrationCourse(PreRegistrationEnt ent)
        {
            try
            {
                ent.DatePreRegistration = DateTime.Now;
                ent.IdState = 1;
                var resp = modelRegitration.CreatePreRegistration(ent);

                if (resp > 0)
                {
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ViewBag.Msg = "No se ha podido registrar su información";
                    return View("4");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }
        [HttpPost]
        public ActionResult Login(UserEnt ent)
        {

            try
            {
                ent.UserPw = model.Encrypt(ent.UserPw);
                var resp = model.Login(ent);

                if (resp != null)
                {

                    Session["IdUser"] = resp.UserId.ToString();
                    Session["IdRoleUser"] = resp.IdRol;
                    Session["[User]"] = resp.UserName;
                    Session["[NameRole]"] = resp.NameRol;
                    Session["TokenUser"] = resp.Token;

                    //var cliente = model.ConsultarCliente(Session["IdUser"]);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Msj = "No se ha podido validar su información";
                    return View("Login");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Msj = "No se ha podido validar su información";
                return View("Login");
            }

        }


        public ActionResult ContactConsult(ContactEnt ent)
        {
            //Programacion envio correo a institucion

            return RedirectToAction("", "");
        }

        public ActionResult RestorerUser(UserEnt ent)
        {
            //Programacion restablecer contraseña y enviar al correo

            return RedirectToAction("", "");
        }

        [HttpGet]
        public ActionResult SingOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }


    }

}