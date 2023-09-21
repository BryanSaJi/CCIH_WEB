using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class UsuarioEnt
    {
        public long IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string PwUsuario { get; set; }
        public long IdOficina { get; set; }
        public long IdCliente { get; set; }
        public long IdRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaActividad { get; set; }
        public long IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public long IdEstatus { get; set; }
        public string NombreRol { get; set; }
        public string Token { get; set; }


    }
}