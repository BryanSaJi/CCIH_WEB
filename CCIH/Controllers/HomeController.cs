﻿
using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
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

        public ActionResult Courses()
        {
            var data = modelCourse.RequestCourseScrollDown();
            return View(data);
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
            var course = modelCourse.RequestCourseScrollDown();
            var ComboCourse = new List<SelectListItem>();
            foreach (var item in course)
            {
                if (item.CourseID <= 3)
                {
                    ComboCourse.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.CourseID.ToString()
                    });
                }
            }

            //Modalidad
            var Modality = modelModality.RequestModalityScrollDown();
            var ComboModality = new List<SelectListItem>();
            foreach (var item in Modality)
            {
                ComboModality.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ModalityId.ToString()
                });
            }

            //level
            var level = modelLevel.RequestLevelCourseScrollDown();
            var Combolevel = new List<SelectListItem>();
            foreach (var item in level)
            {
                Combolevel.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.LevelCourseId.ToString()
                });
            }
            ViewBag.Course = ComboCourse;
            ViewBag.Modality = ComboModality;
            ViewBag.level = Combolevel;
            return View();
        }

        public ActionResult PreRegistrationCourse(PreRegistrationEnt ent)
        {
            try
            {
                ent.DatePreRegistration = DateTime.Now;
                ent.StatusId = 1;
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
                    Session["MensajePositivo"] = 0;
                    Session["IdUser"] = resp.UserId.ToString();
                    Session["IdRoleUser"] = resp.IdRol;
                    Session["[User]"] = resp.UserName;
                    Session["[NameRole]"] = resp.RolName;
                    Session["TokenUser"] = resp.Token;

                    //var cliente = model.ConsultarCliente(Session["IdUser"]);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Msj = "Usuario o Contraseña incorrecto.";
                    //TempData["ErrorMessage"] = "Usuario o Contrasena incorrecto.";
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Usuario o Contrasena incorrecto.";
                return View("Login");
            }

        }


        public ActionResult ContactConsult(ContactEnt ent)
        {
            
            return RedirectToAction("", "");
        }

        public ActionResult RestoreUser(UserEnt ent)
        {
            var resp = model.RestoreUserPassword(ent);
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult SingOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }






    }
}