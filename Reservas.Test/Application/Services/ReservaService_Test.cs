using Reservas.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.Services {
    public class ReservaService_Test {
        [Theory]
        [InlineData(4, false)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        [InlineData(8, false)]
        [InlineData(10, false)]
        [InlineData(20, false)]
        [InlineData(7, false)]
        [InlineData(1, false)]
        public async void GenerarPedido_CheckValidData(int expectedIdReserva, bool isEqual) {
            var ReservaService = new ReservaService();
            int idReserva = await ReservaService.GenerarIdReservaAsync();
            if (isEqual) {
                Assert.Equal(expectedIdReserva, idReserva);
            } else {
                Assert.NotEqual(expectedIdReserva, idReserva);
            }
        }
    }
}
