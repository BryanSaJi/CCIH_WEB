﻿using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class RoleController : Controller
    {
        RoleModel model = new RoleModel();
        // GET: Rol
        [HttpGet]
        public ActionResult ListRoles()
        {
            var data = model.RequetRoles();
            return View(data);
        }


        [HttpPost]
        public ActionResult CreateRole(RoleEnt ent)
        {
            try
            {

                var resp = model.CreateRole(ent);

                if (resp > 0)
                    return RedirectToAction("ListRoles", "Role");
                else
                {
                    ViewBag.Msj = "No se ha podido registrar su información";
                    return View("ListRoles");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }



        [HttpGet]
        public ActionResult RegisterRole()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EditRole(long i)
        {
            var data = model.RequetRole(i);
            data.IdUser = long.Parse(Session["IdUser"].ToString());
            return View(data);
        }
        [HttpPost]
        public ActionResult EditRole(RoleEnt ent)
        {
            try
            {

                var resp = model.EditRole(ent);

                if (resp > 0)
                    return RedirectToAction("ListRoles", "Rol");
                else
                {
                    ViewBag.Msj = "No se ha podido registrar su información";
                    return View("ListRoles");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult DeleteRole(long i)
        {
            try
            {

                var resp = model.DeleteRole(i);

                if (resp > 0)
                    return RedirectToAction("ListRoles", "Rol");
                else
                {
                    ViewBag.Msj = "No se ha podido eliminar el Rol";
                    return View("ListRoles");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }



        [HttpGet]
        public List<RoleEnt> ListRolesScrollDown()
        {
            var data = model.RequestRolesScrollDown();
            return data;
        }

    }
}
