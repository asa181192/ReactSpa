using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaService.Cursos
{
    public class Edit
    {
        public class Cursos : IRequest
        {
            public int CursoId { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public string FotoPortada { get; set; }
        }

        public class CursosHandler : IRequestHandler<Cursos>
        {
            private readonly ApplicattionDbContext _applicattionDbContext;

            public CursosHandler(ApplicattionDbContext applicattionDbContext)
            {
                _applicattionDbContext = applicattionDbContext;
            }


            public async Task<Unit> Handle(Cursos request, CancellationToken cancellationToken)
            {
                var originalEntry = await _applicattionDbContext.Curso.FindAsync(request.CursoId);

                originalEntry.Titulo = request.Titulo;
                originalEntry.Descripcion = request.Descripcion;
                originalEntry.FechaPublicacion = request.FechaPublicacion;

                var result = await _applicattionDbContext.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Cannot edit the course");
            }
        }
    }
}
