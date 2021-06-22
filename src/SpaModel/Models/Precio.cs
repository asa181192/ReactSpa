using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpaModel.Models
{
    public partial class Precio
    {
        public int PrecioId { get; set; }
        public decimal? PrecioActual { get; set; }
        public decimal? Promocion { get; set; }
        public int CursoId { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
