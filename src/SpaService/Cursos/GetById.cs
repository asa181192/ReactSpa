using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaModel.DTO;
using SpaPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaService.Cursos
{
    public class GetById
    {
        public class Cursos : IRequest<CursoDTO>
        {
            public int CursoId { get; set; }
        }

        public class CursosHandler : IRequestHandler<Cursos, CursoDTO>
        {
            private readonly ApplicattionDbContext _applicattionDbContext;

            public CursosHandler(ApplicattionDbContext applicattionDbContext)
            {
                _applicattionDbContext = applicattionDbContext;
            }

            public async Task<CursoDTO> Handle(Cursos request, CancellationToken cancellationToken)
            {
                return await _applicattionDbContext.Curso.
                        Where(x => x.CursoId == request.CursoId).
                        Select(x => new CursoDTO
                        {
                            Titulo = x.Titulo,
                            Descripcion = x.Descripcion
                        }).SingleOrDefaultAsync();
            }
        }
    }
}
