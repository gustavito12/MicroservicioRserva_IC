//using Moq;
using Reservas.Application.Dto.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.Dto {
    public class ReservaDto_Tests {
        [Fact]
        public void RservaDto_CheckPropertiesValid() {
            var idTest = Guid.NewGuid();
            var nroReservaTest = 5;
            var detalleReservaTest = GetDetalleReserva();

            var objReserva = new ReservaDto();

            Assert.Equal(Guid.Empty, objReserva.Id);
            Assert.Equal(0, objReserva.IdReserva);
            Assert.NotNull(objReserva.Detalle);

            objReserva.Id = idTest;
            objReserva.IdReserva = nroReservaTest;
            objReserva.Detalle = (DetalleReservaDto)detalleReservaTest;

            Assert.Equal(idTest, objReserva.Id);
            Assert.Equal(nroReservaTest, objReserva.IdReserva);
            Assert.Equal(detalleReservaTest, objReserva.Detalle);
        }

        private object GetDetalleReserva() {
            DetalleReservaDto DetalleReserva = new() {
                FechaReserva = new DateTime(),
                Importe = 5.4m,
                Estado = 1,
                NumTicket = 5
            };

            return DetalleReserva;
        }
    }
}
