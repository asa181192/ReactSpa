using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpaModel.Models
{
    public partial class Comentario
    {
        public int ComentarioId { get; set; }
        public int AlumnoId { get; set; }
        public int CursoId { get; set; }
        public string Comentario1 { get; set; }
        public int Puntaje { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
