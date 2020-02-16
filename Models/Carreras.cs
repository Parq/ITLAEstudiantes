using System;
using System.Collections.Generic;

namespace EstudiantesITLA.Models
{
    public partial class Carreras
    {
        public Carreras()
        {
            Estudiantes = new HashSet<Estudiantes>();
        }

        public int CodCarrera { get; set; }
        public string NomCarrera { get; set; }

        public virtual ICollection<Estudiantes> Estudiantes { get; set; }
    }
}
