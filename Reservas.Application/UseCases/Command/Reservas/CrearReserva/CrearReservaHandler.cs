using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Application.Services;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Reservas.CrearReserva
{
    public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, Guid>
    {
        private readonly ReservaRepositories _reservaRepository;
        private readonly ILogger<CrearReservaHandler> _logger;
        private readonly IReservaService _reservaService;
        private readonly IReservaFactory _reservaFactory;
        private readonly IUnitOfWorks _unitOfWork;

        public CrearReservaHandler(ReservaRepositories reservaRepository, ILogger<CrearReservaHandler> logger,
            IReservaService reservaService, IReservaFactory reservaFactory, IUnitOfWorks unitOfWork)
        {
            _reservaRepository = reservaRepository;
            _logger = logger;
            _reservaService = reservaService;
            _reservaFactory = reservaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearReservaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int IdReserva = await _reservaService.GenerarIdReservaAsync();
                Reserva objReserva = _reservaFactory.Create(IdReserva);                         

                objReserva.CargaReservaDetalle(request.Detalle.FechaReserva, request.Detalle.Importe, request.Detalle.Estado, request.Detalle.NumTicket);

                objReserva.RegistrarReserva();

                await _reservaRepository.CreateAsync(objReserva);

                await _unitOfWork.Commit();

                return objReserva.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear reserva");
            }
            return Guid.Empty;
        }
    }
}
