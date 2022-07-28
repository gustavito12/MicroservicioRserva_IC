using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.Dto.Reserva;
using Reservas.Application.UseCases.Command.Reservas.CrearReserva;
using Reservas.Application.UseCases.Queries.Reservas.GetReservaById;
using Reservas.Application.UseCases.Queries.Reservas.SearchReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.WebApi.Controllers {
    [ApiController]
    [Route("/api/[controller]")]
    public class ReservaController : Controller {
        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearReservaCommand command) {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetPedidoById([FromRoute] GetReservaByIdQuery command) {
            ReservaDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("search")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchReservaQuery query) {
            var reservas = await _mediator.Send(query);

            if (reservas == null)
                return BadRequest();

            return Ok(reservas);
        }

        [Route("Search_Todo")]
        [HttpPost]
        public async Task<IActionResult> Search_Todo([FromBody] SearchReservaQuery query) {
            var reservas = await _mediator.Send(query);

            if (reservas == null)
                return BadRequest();

            return Ok(reservas);
        }
    }
}
