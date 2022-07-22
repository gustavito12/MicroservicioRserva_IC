using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Pagos
{
    public class Pago : Entity<Guid>
    {
        public int TipoCombrobante { get; private set; }
        public DateTime FechaPago { get; private set; }
        public int TipoPago{ get; private set; }
        public string NumFactura { get; private set; }
        public decimal NumRecibo { get; private set; }
        public decimal TotalPagado { get; private set; }

        internal Pago(int tipoCombrobante, DateTime fechaPago, int tipoPago, string numFactura, decimal totalPagado)
        {
            Id = Guid.NewGuid();
            TipoCombrobante = tipoCombrobante;
            FechaPago = fechaPago;
            TipoPago = tipoPago;
            NumFactura = numFactura;
            TotalPagado = totalPagado;
        }

        internal Pago(int tipoCombrobante, DateTime fechaPago, int tipoPago, decimal numRecibo, decimal totalPagado)
        {
            Id = Guid.NewGuid();
            TipoCombrobante = tipoCombrobante;
            FechaPago = fechaPago;
            TipoPago = tipoPago;
            NumRecibo = numRecibo;
            TotalPagado = totalPagado;
        }
    }
}
