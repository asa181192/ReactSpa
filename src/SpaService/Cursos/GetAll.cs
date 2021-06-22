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
    public class GetAll
    {
        public class Cursos : IRequest<List<CursoDTO>> { }

        public class CursosHandler : IRequestHandler<Cursos, List<CursoDTO>>
        {
            private readonly ApplicattionDbContext _applicattionDbContext;

            public CursosHandler(ApplicattionDbContext applicattionDbContext)
            {
                _applicattionDbContext = applicattionDbContext;
            }

            public async Task<List<CursoDTO>> Handle(Cursos request, CancellationToken cancellationToken)
            {
                return await _applicattionDbContext.Curso.Select(x => new CursoDTO
                {
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion
                }).ToListAsync();
            }
        }
    }
}
