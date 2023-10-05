using API_CentroCultural.Entities;
using CCIH.Entities;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Controllers
{
    public class StateController : Controller
    {

        StateModel modelState = new StateModel();


        [HttpGet]
        public List<StateEnt> ListStateScrollDown()
        {
            var data = modelState.RequestStatusScrollDown();
            return data;
        }
    }
}