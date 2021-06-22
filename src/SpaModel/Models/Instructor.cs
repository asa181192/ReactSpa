using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpaModel.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            CursoInstructor = new HashSet<CursoInstructor>();
        }

        public int InstructorId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Grado { get; set; }
        public string FotoPerfil { get; set; }

        public virtual ICollection<CursoInstructor> CursoInstructor { get; set; }
    }
}
