using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Application.Dto.Reserva;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Queries.Reservas.GetReservaById
{
    public class GetReservaByIdHandler : IRequestHandler<GetReservaByIdQuery, ReservaDto>
    {
        private readonly ReservaRepositories _reservaRepository;
        private readonly ILogger<GetReservaByIdQuery> _logger;

        public GetReservaByIdHandler(ReservaRepositories reservaRepository, ILogger<GetReservaByIdQuery> logger)
        {
            _reservaRepository = reservaRepository;
            _logger = logger;
        }

        public async Task<ReservaDto> Handle(GetReservaByIdQuery request, CancellationToken cancellationToken)
        {
            ReservaDto result = null;
            try
            {
                Reserva objReserva = await _reservaRepository.FindByIdAsync(request.Id);

                result = new ReservaDto()
                {
                    Id = objReserva.Id,
                    IdReserva = objReserva.IdReserva,
                    //Detalle = objReserva.Detalle

                };     
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener reserva con id: { PedidoId }", request.Id);
            }

            return result;
        }
    }
}
