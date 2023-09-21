using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class ContactoEnt
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Curso { get; set; }
        public string Motivo { get; set; }
        public string Mensaje { get; set; }
    }
}