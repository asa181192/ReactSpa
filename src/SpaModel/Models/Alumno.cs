using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpaModel.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Comentario = new HashSet<Comentario>();
        }

        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FotoPerfil { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comentario> Comentario { get; set; }
    }
}
