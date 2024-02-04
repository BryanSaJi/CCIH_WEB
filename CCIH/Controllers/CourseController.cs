using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Windows.Documents;


namespace CCIH.Controllers
{
    
    public class CourseController : Controller
    {

        CourseModel modelCourse = new CourseModel();
        ModalityModel modalityModel = new ModalityModel();
        StateModel StateModel = new StateModel();
        LevelModel LevelModel = new LevelModel();

        public ActionResult Index()
        {
            try
            {
                var data = modelCourse.RequestCourseScrollDown();
                return View(data);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
           
        }


        [AllowAnonymous]
        public ActionResult ObtenerCursosDesdeBaseDeDatos(string name)
        {
            try
            {
                var list = modelCourse.SeeCoursesFiltered(name).ToList();

                // Convertir la lista de cursos a JSON
                var jsonCursos = Json(list, JsonRequestBehavior.AllowGet);

                // Devolver los datos JSON
                return jsonCursos;
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }

        [Authorize]
        [HttpGet]
        public ActionResult ShowCourses()
        {
            try
            {
                var Data = modelCourse.RequestCourseScrollDown();

                if ((int)Session["MensajePositivo"] == 1)
                {

                    ViewBag.MsjPantallaPostivo = "El curso fue modificado de manera correcta.";
                }


                if ((int)Session["MensajeNegativo"] == 2)
                {

                    ViewBag.MsjPantallaNegativo = "No se ha podido modificar el curso.";
                }


                if ((int)Session["MensajePositivo"] == 3)
                {

                    ViewBag.MsjPantallaPostivo = "El curso fue agregado de manera correcta.";
                }


                if ((int)Session["MensajeNegativo"] == 4)
                {

                    ViewBag.MsjPantallaNegativo = "No se ha podido agregar el curso.";
                }

                return View(Data);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }


        [Authorize]
        [HttpGet]
        public ActionResult EditCourse(long courseId)
        {

            try
            {
                var resp = modelCourse.RequestCourseByID(courseId);


                //CourseName
                var CourseCatalog = modelCourse.SeeCourseCatalog();
                var ComboCourse = new List<SelectListItem>();

                foreach (var item in CourseCatalog)
                {
                    if (resp.CourseName == item.CourseName)
                    {
                        ComboCourse.Add(new SelectListItem
                        {
                            Text = item.CourseName,
                            Value = item.CourseCatalogId.ToString(),
                            Selected = true
                        });
                    }
                    else
                    {

                        ComboCourse.Add(new SelectListItem
                        {
                            Text = item.CourseName,
                            Value = item.CourseCatalogId.ToString(),
                            Selected = false
                        });
                    }

                }
                ViewBag.CourseName = ComboCourse;


                //Modality
                var Modality = modalityModel.RequestModalityScrollDown();
                var ComboModality = new List<SelectListItem>();
                foreach (var item in Modality)
                {


                    if (resp.ModalityName == item.Name)
                    {
                        ComboModality.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.ModalityId.ToString(),
                            Selected = true
                        });

                    }
                    else
                    {

                        ComboModality.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.ModalityId.ToString(),
                            Selected = false
                        });

                    }
                }


                ViewBag.Modality = ComboModality;


                //Level
                var Level = LevelModel.RequestLevelCourseScrollDown();
                var ComboLevel = new List<SelectListItem>();
                foreach (var item in Level)
                {

                    if (resp.LevelCourseName == item.Name)
                    {
                        ComboLevel.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.LevelCourseId.ToString(),
                            Selected = true
                        });

                    }
                    else
                    {

                        ComboLevel.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.LevelCourseId.ToString(),
                            Selected = false
                        });

                    }



                }
                ViewBag.Level = ComboLevel;


                //Status
                var Status = StateModel.RequestStatusScrollDown();
                var ComboStatus = new List<SelectListItem>();
                foreach (var item in Status)
                {


                    if (item.StatusId >= 1 && item.StatusId <= 2)
                    {

                        if (resp.statusname == item.Name)
                        {
                            ComboStatus.Add(new SelectListItem
                            {
                                Text = item.Name,
                                Value = item.StatusId.ToString(),
                                Selected = true
                            });

                        }
                        else
                        {

                            ComboStatus.Add(new SelectListItem
                            {
                                Text = item.Name,
                                Value = item.StatusId.ToString(),
                                Selected = false
                            });

                        }



                    }

                }
                ViewBag.Status = ComboStatus;


                if ((int)Session["MensajePositivo"] == 1)
                {

                    ViewBag.MsjPantallaPostivo = "El curso fue modificado de manera correcta.";
                }


                if ((int)Session["MensajeNegativo"] == 2)
                {

                    ViewBag.MsjPantallaNegativo = "No se ha podido modificar el curso.";
                }


                return View(resp);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }


            

        }




        [HttpGet]
        public ActionResult AddCourse()
        {

            try
            {
                //CourseName
                var CourseCatalog = modelCourse.SeeCourseCatalog();
                var ComboCourse = new List<SelectListItem>();

                foreach (var item in CourseCatalog)
                {

                    ComboCourse.Add(new SelectListItem
                    {
                        Text = item.CourseName,
                        Value = item.CourseCatalogId.ToString(),
                        Selected = true
                    });


                }
                ViewBag.CourseName = ComboCourse;


                //Modality
                var Modality = modalityModel.RequestModalityScrollDown();
                var ComboModality = new List<SelectListItem>();
                foreach (var item in Modality)
                {


                    ComboModality.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ModalityId.ToString(),
                        Selected = true
                    });

                }


                ViewBag.Modality = ComboModality;


                //Level
                var Level = LevelModel.RequestLevelCourseScrollDown();
                var ComboLevel = new List<SelectListItem>();
                foreach (var item in Level)
                {

                    ComboLevel.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.LevelCourseId.ToString(),
                        Selected = true
                    });


                }
                ViewBag.Level = ComboLevel;


                //Status
                var Status = StateModel.RequestStatusScrollDown();
                var ComboStatus = new List<SelectListItem>();
                foreach (var item in Status)
                {

                    if (item.StatusId > 0 && item.StatusId < 3)
                    {
                        ComboStatus.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.StatusId.ToString(),
                            Selected = true
                        });
                    }


                }
                ViewBag.Status = ComboStatus;





                if ((int)Session["MensajePositivo"] == 1)
                {

                    ViewBag.MsjPantallaPostivo = "El curso fue agregado de manera correcta.";
                }


                if ((int)Session["MensajeNegativo"] == 2)
                {

                    ViewBag.MsjPantallaNegativo = "No se ha podido agregar el curso.";
                }


                return View();
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            

        }







        [AllowAnonymous]
        public ActionResult SendInfoEditCourse(CourseEnt courseEnt, HttpPostedFileBase image)
        {

            try
            {
                if (courseEnt.Description == null)
                {
                    courseEnt.Description = "Sin Descripcion";
                }

                if (courseEnt.image == null)
                {
                    courseEnt.image = "Sin Imagen";
                }


                //if (image != null && image.ContentLength > 0)
                //{


                //    var fileName = Path.GetFileName(image.FileName);

                //    string nombreSinExtension = Path.GetFileNameWithoutExtension(fileName);

                //    // Obtener la extensión del archivo
                //    string extension = Path.GetExtension(fileName);

                //    // Generar un identificador único (GUID)
                //    string identificadorUnico = Guid.NewGuid().ToString();

                //    // Combinar el identificador único con el nombre del archivo original y la extensión
                //    string newName = $"{nombreSinExtension}_{identificadorUnico}{extension}";

                //    courseEnt.image = newName;


                //    string path = Path.Combine(Server.MapPath("../assets/Administration/img/"), newName);
                //    image.SaveAs(path);

                //}


                if (image != null && image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    string nombreSinExtension = Path.GetFileNameWithoutExtension(fileName);
                    string extension = Path.GetExtension(fileName);

                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(fileName));
                        string identificadorUnico = BitConverter.ToString(hash).Replace("-", "").Substring(0, 8);

                        string newName = $"{nombreSinExtension}_{identificadorUnico}{extension}";
                        courseEnt.image = newName;

                        string path = Path.Combine(Server.MapPath("../assets/Home/img/"), newName);
                        image.SaveAs(path);
                    }
                }



                var Data = 0;

                if (courseEnt == null)
                {
                    Session["MensajeNegativo"] = 2;
                }
                else
                {

                    Data = modelCourse.EditCourse(courseEnt);

                    if (Data > 0)
                    {
                        Session["MensajePositivo"] = 1;
                    }
                    else
                    {
                        Session["MensajeNegativo"] = 2;
                    }
                }



                // Convertir la lista de cursos a JSON
                var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);


                // Devolver los datos JSON
                return jsonCursos;
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
           
        }




        [AllowAnonymous]
        public ActionResult SendInfoAddCourse(CourseEnt courseEnt, HttpPostedFileBase image)
        {

            try
            {
                if (courseEnt.Description == null)
                {
                    courseEnt.Description = "Sin Descripcion";
                }

                if (courseEnt.image == null)
                {
                    courseEnt.image = "Sin Imagen";
                }


                //if (image != null && image.ContentLength > 0)
                //{


                //    var fileName = Path.GetFileName(image.FileName);

                //    string nombreSinExtension = Path.GetFileNameWithoutExtension(fileName);

                //    // Obtener la extensión del archivo
                //    string extension = Path.GetExtension(fileName);

                //    // Generar un identificador único (GUID)
                //    string identificadorUnico = Guid.NewGuid().ToString();

                //    // Combinar el identificador único con el nombre del archivo original y la extensión
                //    string newName = $"{nombreSinExtension}_{identificadorUnico}{extension}";

                //    courseEnt.image = newName;


                //    string path = Path.Combine(Server.MapPath("../assets/Administration/img/"), newName);
                //    image.SaveAs(path);

                //}

                if (image != null && image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    string nombreSinExtension = Path.GetFileNameWithoutExtension(fileName);
                    string extension = Path.GetExtension(fileName);

                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(fileName));
                        string identificadorUnico = BitConverter.ToString(hash).Replace("-", "").Substring(0, 8);

                        string newName = $"{nombreSinExtension}_{identificadorUnico}{extension}";
                        courseEnt.image = newName;

                        string path = Path.Combine(Server.MapPath("../assets/Home/img/"), newName);
                        image.SaveAs(path);
                    }
                }




                var Data = 0;

                if (courseEnt == null)
                {
                    Session["MensajeNegativo"] = 4;
                }
                else
                {

                    Data = modelCourse.CreateCourse(courseEnt);

                    if (Data > 0)
                    {
                        Session["MensajePositivo"] = 3;
                    }
                    else
                    {
                        Session["MensajeNegativo"] = 4;
                    }
                }



                // Convertir la lista de cursos a JSON
                var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);


                // Devolver los datos JSON
                return jsonCursos;
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }

            
        }




        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {

                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("../assets/Home/img/"), fileName);
                    file.SaveAs(path);
                    return Json(new { success = true, message = "Imagen subida correctamente" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Error al subir la imagen: " + ex.Message });
                }
            }
            return Json(new { success = false, message = "Archivo no válido" });
        }

        /****************************************************************************************************************/


        [HttpGet]
        public ActionResult ShowCourseCatalog()
        {
            try
            {
                var Data = modelCourse.SeeCourseCatalog();

                if ((int)Session["MensajePositivo"] == 1)
                {

                    ViewBag.MsjPantallaPostivo = "El curso fue agregado al catalogo de manera correcta.";
                }


                if ((int)Session["MensajeNegativo"] == 2)
                {

                    ViewBag.MsjPantallaNegativo = "No se ha podido agregar el curso al catalogo.";
                }

                if ((int)Session["MensajePositivo"] == 3)
                {

                    ViewBag.MsjPantallaPostivo = "El curso fue modificado en el catalogo de manera correcta.";
                }


                if ((int)Session["MensajeNegativo"] == 4)
                {

                    ViewBag.MsjPantallaNegativo = "No se ha podido modificar el curso en el catalogo.";
                }

                if ((int)Session["MensajePositivo"] == 5)
                {

                    ViewBag.MsjPantallaPostivo = "El curso fue eliminado en el catalogo de manera correcta.";
                }


                if ((int)Session["MensajeNegativo"] == 6)
                {

                    ViewBag.MsjPantallaNegativo = "No se ha podido eliminar el curso en el catalogo.";
                }

                return View(Data);
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }
            
        }


        [AllowAnonymous]
        public ActionResult EditCourseCatalog(string courseName, string LastName)
        {

            try
            {
                var courseId = modelCourse.SeeCoursesCatalogByName(LastName);

                var Data = 0;

                if (courseName.IsEmpty() || courseId <= 0)
                {
                    Session["MensajeNegativo"] = 4;
                }
                else
                {
                    CourseCatalogEnt courseCatalogEnt = new CourseCatalogEnt();
                    courseCatalogEnt.CourseCatalogId = courseId;
                    courseCatalogEnt.CourseName = courseName;

                    Data = modelCourse.EditCourseCatalog(courseCatalogEnt);

                    if (Data > 0)
                    {
                        Session["MensajePositivo"] = 3;
                    }
                    else
                    {
                        Session["MensajeNegativo"] = 4;
                    }
                }



                // Convertir la lista de cursos a JSON
                var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);


                // Devolver los datos JSON
                return jsonCursos;
            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }

            
        }



        [AllowAnonymous]
        public ActionResult DeleteCourseCatalog(string currentCourseName)
        {

            try
            {
                var courseId = modelCourse.SeeCoursesCatalogByName(currentCourseName);


                if (courseId != 0)
                {

                    var Data = modelCourse.DeleteCoursesCatalog(courseId);

                    if (Data > 0)
                    {
                        Session["MensajePositivo"] = 5;
                    }
                    else
                    {
                        Session["MensajeNegativo"] = 6;
                    }

                    // Convertir la lista de cursos a JSON
                    var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);

                    // Devolver los datos JSON
                    return jsonCursos;

                }
                else
                {
                    Session["MensajeNegativo"] = 6;

                    var Data = 0;

                    // Convertir la lista de cursos a JSON
                    var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);

                    // Devolver los datos JSON
                    return jsonCursos;
                }

            }
            catch (Exception ex)
            {
                var exept = ex.Message;
                return RedirectToAction("ErrorAdministration", "Error");
            }

            

        }



        [HttpPost]
        public ActionResult CreateCourseCatalog(string courseName)
        {
            try
            {
                var courseId = modelCourse.SeeCoursesCatalogByName(courseName);

                if (courseId != 0)
                {

                    var Data = modelCourse.CreateCourseCatalog(courseName);

                    if (Data > 0)
                    {
                        Session["MensajePositivo"] = 1;
                    }
                    else
                    {
                        Session["MensajeNegativo"] = 2;
                    }

                    // Convertir la lista de cursos a JSON
                    var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);

                    // Devolver los datos JSON
                    return jsonCursos;
                }
                else
                {
                    Session["MensajeNegativo"] = 2;

                    var Data = 0;

                    // Convertir la lista de cursos a JSON
                    var jsonCursos = Json(Data, JsonRequestBehavior.AllowGet);

                    // Devolver los datos JSON
                    return jsonCursos;
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