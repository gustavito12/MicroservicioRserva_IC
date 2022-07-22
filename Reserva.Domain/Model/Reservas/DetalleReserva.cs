using Reservas.Domain.Model.Reservas.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reservas
{
    public class DetalleReserva : Entity<Guid>
    {
        //TODO: Crear value objects para las propiedades
     
        public DateTime FechaReserva { get;  set; }
        public MinimoPago Importe { get;  set; }
        public int Estado { get;  set; }
        public int NumTicket { get;  set; }

        internal DetalleReserva(DateTime fechaReserva, decimal importe,int estado, int numTicket)
        {
            Id = Guid.NewGuid();
            FechaReserva = fechaReserva;
            Importe = importe;
            Estado = estado;
            NumTicket = numTicket;   
        }

        public DetalleReserva()
        {
        }
    }
}
