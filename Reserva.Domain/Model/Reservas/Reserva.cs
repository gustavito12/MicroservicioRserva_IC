using Reservas.Domain.Event.Reservas;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.Reservas.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reservas
{
    public class Reserva : AggregateRoot<Guid>
    {
        public Guid VueloId { get; private set; }
        public Guid IDPasajero { get; private set; }
        public Guid IDPago     { get; private set; }
        public int IdReserva { get; private set; }
        private readonly ICollection<DetalleReserva> _detalle;
        public Pago DetallePago { get; private set; }

        public IReadOnlyCollection<DetalleReserva> Detalle
        {
            get
            {
                return new ReadOnlyCollection<DetalleReserva>(_detalle.ToList());
            }
        }

        public Reserva(int idReserva)
        {
            Id = Guid.NewGuid();
            IdReserva = idReserva;
            _detalle = new List<DetalleReserva>();
        }


        private Reserva()
        {
            
        }

        public void CargaReservaDetalle(DateTime fechaReserva, decimal importe, int estado,int numTicket)
        {
            var detalleReserva = new DetalleReserva(fechaReserva, importe, estado, numTicket);
            _detalle.Add(detalleReserva);

            AddDomainEvent(new DetalleReservaAgregado(fechaReserva, importe, estado, numTicket));
        }

        public void CargaReservaPago(int tipoCombrobante, DateTime fechaPago, int tipoPago, string numFactura, decimal numRecibo, decimal totalPagado)
        {
            DetallePago = new Pago(tipoCombrobante, fechaPago, tipoPago, numFactura, totalPagado);
        }

        public void RegistrarReserva()
        {
            var evento = new ReservaRealizada(Id, IdReserva);
            AddDomainEvent(evento);
        }
    }
}
