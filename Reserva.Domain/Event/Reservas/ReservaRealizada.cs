using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.Reservas;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Event.Reservas
{
    public record ReservaRealizada : DomainEvent
    {
        public Guid CodReserva { get; }
        public int IdReserva { get; }
        public DetalleReserva Detalle { get; }
        public Pago DetallePago { get; }

        public ReservaRealizada(Guid codReserva, int idReserva, DetalleReserva detalle, Pago detallePago) : base(DateTime.Now)
        {
            CodReserva = codReserva;
            IdReserva = idReserva;
            Detalle = detalle;
            DetallePago = detallePago;

        }
        public ReservaRealizada(Guid codReserva, int idReserva) : base(DateTime.Now)
        {
            CodReserva = codReserva;
            IdReserva = idReserva;
        }
    }
}
