using Reservas.Domain.Model.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.Dto.Reserva
{
    public class ReservaDto
    {
        public Guid Id { get; set; }
        public int IdReserva { get;  set; }
        public DetalleReservaDto Detalle { get;  set; }
        
        public ReservaDto()
        {
            Detalle = new DetalleReservaDto();
        }
    }
}
