using MediatR;
using SpaPersistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaService.Cursos
{
    public class Remove
    {
        public class Cursos : IRequest
        {
            public int CursoId { get; set; }
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

                _applicattionDbContext.Remove(originalEntry);

                var result = await _applicattionDbContext.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Cannot delete the course");
            }
        }
    }
}
