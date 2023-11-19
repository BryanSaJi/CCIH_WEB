using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class GroupController : Controller
    {

        GroupModel modelGroup = new GroupModel();

        // GET: Group
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult ShowGroups()
        {
            var Data = modelGroup.RequestGroupScrollDown();

            return View(Data);
        }
    }
}