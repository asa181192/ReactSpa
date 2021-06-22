using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaModel.DTO;
using SpaService.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CursosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CursoDTO>> GetAll()
        {
            return await _mediator.Send(new GetAll.Cursos());
        }

        [HttpGet("{id}")]
        public async Task<CursoDTO> GetById(int id)
        {
            return await _mediator.Send(new GetById.Cursos()
            {
                CursoId = id
            });
        }

        [HttpPost()]
        public async Task<ActionResult<Unit>> Add(Add.Cursos model)
        {
            return await _mediator.Send(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Cursos model)
        {
            model.CursoId = id;
            return await _mediator.Send(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Remove(int id)
        {
            return await _mediator.Send(new Remove.Cursos()
            {
                CursoId = id
            });
        }



    }
}
