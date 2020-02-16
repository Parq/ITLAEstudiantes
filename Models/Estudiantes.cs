using System;
using System.Collections.Generic;

namespace EstudiantesITLA.Models
{
    public partial class Estudiantes
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int CodCarrera { get; set; }
        public bool Activo { get; set; }

        public virtual Carreras CodCarreraNavigation { get; set; }
    }
}
