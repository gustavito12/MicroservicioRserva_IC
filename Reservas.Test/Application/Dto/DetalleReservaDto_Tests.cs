using Reservas.Application.Dto.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.Dto
{
    public class DetalleReservaDto_Tests
    {
        [Fact]
        public void DetallePedidoDto_CheckPropertiesValid()
        {
            var FechaReservaTest = new DateTime();
            decimal Importetest = new(40.0);
            var EstadoTest = 5;
            var NumTicketTest = 5;

            var detalleReserva = new DetalleReservaDto();

            Assert.Equal(new DateTime(), detalleReserva.FechaReserva);
            Assert.Equal(new decimal(0.0), detalleReserva.Importe);
            Assert.Equal(0, detalleReserva.Estado);
            Assert.Equal(0, detalleReserva.NumTicket);


            detalleReserva.FechaReserva = FechaReservaTest;
            detalleReserva.Importe = Importetest;
            detalleReserva.Estado = EstadoTest;
            detalleReserva.NumTicket = NumTicketTest;

            Assert.Equal(FechaReservaTest, detalleReserva.FechaReserva);
            Assert.Equal(Importetest, detalleReserva.Importe);
            Assert.Equal(EstadoTest, detalleReserva.Estado);
            Assert.Equal(NumTicketTest, detalleReserva.NumTicket);
        }
    }
}
