
using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

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
            try
            {
                var data = modelCourse.RequestCourseScrollDown();
                return View(data);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return RedirectToAction("ErrorHome", "Error");
            }
        }

        public ActionResult Teachers()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
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
            try {
                //Crusos
                var course = modelCourse.RequestCourseScrollDown();
                var ComboCourse = new List<SelectListItem>();
                foreach (var item in course)
                {
                    if (item.CourseID <= 3)
                    {
                        ComboCourse.Add(new SelectListItem
                        {
                            Text = item.CourseName,
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
            catch (Exception ex)
            {
                var message = ex.Message;
                return RedirectToAction("ErrorHome", "Error");
            }
            
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
                    return RedirectToAction("PreRegister", "Home");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorHome", "Error");
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

                    FormsAuthentication.SetAuthCookie(resp.Email, false);

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Msj = "Usuario o Contraseña incorrecto.";
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                TempData["ErrorMessage"] = "Usuario o Contrasena incorrecto.";
                return View("Login");
            }

        }



        public ActionResult RestoreUser(UserEnt ent)
        {
            var resp = model.RestoreUserPassword(ent);
            return RedirectToAction("Login", "Home");
        }

        
        [HttpGet]
        [Authorize]
        public ActionResult SingOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Login", "Home");
        }












        public ActionResult prueba()
        {
            return View();
        }



    }
}