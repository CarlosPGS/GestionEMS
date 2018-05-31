using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class GrupoClases
    {
        public enum TurnoType
        {
            Mañana,
            Tarde
        }
        public int Id { get; set; }
        public string nombre { get; set; }
        public int numAlumnos { get; set; }
        public TurnoType turno { get; set; }
    }
}