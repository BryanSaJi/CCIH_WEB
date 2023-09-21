using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class CambiarContrasennaEnt
    {
        public long IdUsuario { get; set; }
        public string PwNuevo { get; set; }
        public string PWActual { get; set; }
        public string ConfirmPw { get; set; }
    }
}