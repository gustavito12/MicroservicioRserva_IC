using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class DetalleReservaReadModel
    {
        public Guid Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public  decimal Importe { get; set; }
        public int Estado { get; set; }
        public int NumTicket { get; set; }
        public ReservaReadModel Reserva { get; set; }
}
}
