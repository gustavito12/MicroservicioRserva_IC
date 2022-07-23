using Reservas.Application.Dto.Reserva;
using Reservas.Application.UseCases.Command.Reservas.CrearReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.UserCases.Command {
    public class CrearReservaCommand_Tests {
        [Fact]
        public void IsRequest_Valid() {
            var detalleTest = new DetalleReservaDto();
            var command = new CrearReservaCommand(detalleTest);

            Assert.NotNull(command.Detalle);
        }

        [Fact]
        public void TestConstructor_IsPrivate() {
            var command = (CrearReservaCommand)Activator.CreateInstance(typeof(CrearReservaCommand), true);
            Assert.Null(command.Detalle);
        }
    }
}
