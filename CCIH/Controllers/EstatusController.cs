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
    public class EstatusController : Controller
    {
        EstatusModel model = new EstatusModel();


        [HttpGet]
        public List<EstatusEnt> ListarEstatusScrollDown()
        {
            var datos = model.ConsultarEstatusListarRolesScrollDown();
            return datos;
        }
    }
}