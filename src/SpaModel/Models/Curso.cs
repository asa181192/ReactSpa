using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpaModel.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Comentario = new HashSet<Comentario>();
            CursoInstructor = new HashSet<CursoInstructor>();
            Precio = new HashSet<Precio>();
        }

        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string FotoPortada { get; set; }

        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<CursoInstructor> CursoInstructor { get; set; }
        public virtual ICollection<Precio> Precio { get; set; }
    }
}
