using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities.Administracion
{
    public class ClienteEnt
    {
        public long IdCliente { get; set; }
        public String Cedula { get; set; }
        public String Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdEstatus { get; set; }
        public int IdRol { get; set; }

    }
}