﻿using CCIH.Entities;
using CCIH.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using System.Windows.Markup.Localizer;

namespace CCIH.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        UserModel model = new UserModel();
        RoleModel modelRole = new RoleModel();
        StateModel modelState = new StateModel();
        TeacherModel modelTeacher = new TeacherModel();


        [HttpGet]
        public ActionResult Index()
        {
        
            var data = modelTeacher.MarkHistory();


            return View(data);

        }

       

     
        public ActionResult RequestTeacher()
        {
            var data = modelTeacher.RequestTeachers();
            
                return View(data);
        }

        [HttpPost]
        public ActionResult TimeMarkTeacher(long i)
        {
            int user = int.Parse(Session["IdUser"].ToString());

            TeacherEnt ent = new TeacherEnt();

            if (i > 0)
            {
                if (i == 1)
                {
                    ent.Office_SH_ID = ent.Office_SH_ID;
                    ent.EntryTime = DateTime.Now;
                    ent.UserId = user;

                    // Obtener el off ID 
                    int office_SH_ID = modelTeacher.EntryMark(ent);

                    // Guardar el off ID 
                    Session["Office_SH_ID"] = office_SH_ID;
                }
                else if (i == 2)
                {
            
                    ent.Office_SH_ID = (int)Session["Office_SH_ID"];
                    ent.ExitTime = DateTime.Now;
                    modelTeacher.ExitMark(ent);

                      
                    
                }
            }

            return View();
        }



        [HttpGet]
        public ActionResult TimeMarkTeacher()
        {
           return View();
        }




       

        [HttpGet]
        public ActionResult AllHours(long i)
        {
            var data = modelTeacher.TotalWorkHours();

            List<TeacherEnt> dato = new List<TeacherEnt>(); // Inicializa dato como una lista vacía

            foreach (var item in data)
                {
                        if (item.UserId == i)
                        {
                         dato.Add(item);
                        }
                }

            dato = dato.OrderByDescending(x => x.EntryTime).ToList();

            return View(dato);
            
        }





        [HttpGet]
        public ActionResult TotalWorkHours()
        {
            var data = modelTeacher.TotalWorkHours();
            return View(data);
        }



        [HttpGet]
        public ActionResult RequestTeachersSchedules()
        {
            var data = modelTeacher.RequestTeachersSchedules();
            return View(data);
        }
    }

}



