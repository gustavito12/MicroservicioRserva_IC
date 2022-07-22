using MediatR;
using Reservas.Application.Dto.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Queries.Reservas.SearchReserva
{
    public class SearchReservaQuery : IRequest<ICollection<ReservaDto>>
    {
        public int IdReserva { get; set; }
    }
}
