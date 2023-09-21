using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class MatriculaEnt
    {
        public int IdMatricula { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Curso { get; set; }
        public string Modalidad { get; set; }
        public string Nivel { get; set; }
        public string Horario { get; set; }

        public int IdCurso { get; set; }
        public int IdModalidad { get; set; }
        public int IdNivel { get; set; }
        public int IdHorario { get; set; }
        public Decimal Monto { get; set; }
        public DateTime FechaMatricula { get; set; }
        public int DiaPago { get; set; }
        public string Comentario { get; set; }
        public int IdEstatus { get; set; }
        public string Estatus { get; set; }

    }
}