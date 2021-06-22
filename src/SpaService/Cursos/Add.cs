using MediatR;
using SpaModel.DTO;
using SpaModel.Models;
using SpaPersistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaService.Cursos
{
    public class Add 
    {
        public class Cursos : IRequest {
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
                var curso = new Curso()
                {
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion,
                    FotoPortada = request.FotoPortada
                };

                await _applicattionDbContext.AddAsync(curso);
                var result = await _applicattionDbContext.SaveChangesAsync();

                if(result > 0 )
                {
                    return Unit.Value;
                }

                throw new Exception("Cannot add the course");
            }
        }
    }
}
