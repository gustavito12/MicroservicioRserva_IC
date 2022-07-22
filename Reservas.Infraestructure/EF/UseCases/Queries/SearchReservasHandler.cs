using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservas.Application.Dto.Reserva;
using Reservas.Application.UseCases.Queries.Reservas.SearchReserva;
using Reservas.Infraestructure.EF.Contexts;
using Reservas.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.UseCases.Queries
{
    public class SearchReservasHandler : IRequestHandler<SearchReservaQuery, ICollection<ReservaDto>>
    {

        private readonly DbSet<ReservaReadModel> _reservas;

        public SearchReservasHandler(ReadDBContext context)
        {
            _reservas = context.Reserva;
        }

        public async Task<ICollection<ReservaDto>> Handle(SearchReservaQuery request, CancellationToken cancellationToken)
        {
            var ReservaList = await _reservas
                               .Include(x => x.Detalle)
                               .Where(x => x.IdReserva.ToString().Contains(request.IdReserva.ToString()))
                               .ToListAsync();

            var result = new List<ReservaDto>();

            foreach (var objReserva in ReservaList)
            {
                var reservaDto = new ReservaDto()
                {
                    Id = objReserva.Id,
                    IdReserva = objReserva.IdReserva,
                };

                foreach (var item in objReserva.Detalle)
                {
                    reservaDto.Detalle.FechaReserva = item.FechaReserva;
                    reservaDto.Detalle.Importe = item.Importe;
                    reservaDto.Detalle.Estado = item.Estado;
                    reservaDto.Detalle.NumTicket = item.NumTicket;
                }

                result.Add(reservaDto);
            }

            return result;

        }
    }
}
