using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.Dto.Reserva
{
    public class DetalleReservaDto
    {

        //public Guid IdVuelo { get; set; }
        public DateTime FechaReserva { get; set; }
        public decimal Importe { get; set; }
        public int Estado { get; set; }
        public int NumTicket { get; set; }
    }
}
