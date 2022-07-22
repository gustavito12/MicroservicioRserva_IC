using Reservas.Domain.Model.Reservas.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Event.Reservas
{
    public record DetalleReservaAgregado : DomainEvent
    {

        public DateTime FechaReserva { get;  }
        public MinimoPago Importe { get;  }
        public int Estado { get;  }
        public int NumTicket { get;  }

        public DetalleReservaAgregado(DateTime fechaReserva, decimal importe, int estado, int numTicket) : base(DateTime.Now)
        {
            FechaReserva = fechaReserva;
            Importe = new MinimoPago(0m);
            Estado = estado;
            NumTicket = numTicket;
        }
    }
}
