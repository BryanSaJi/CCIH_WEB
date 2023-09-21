using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class PreMatriculaEnt
    {
        public int IdPrematricula { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int IdCurso { get; set; }
        public int IdModalidad { get; set; }
        public int IdNivel { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaPreMatricula { get; set; }

        public string Curso { get; set; }
        public string Modalidad { get; set; }
        public string Nivel { get; set; }
        public string Estatus { get; set; }

    }
}