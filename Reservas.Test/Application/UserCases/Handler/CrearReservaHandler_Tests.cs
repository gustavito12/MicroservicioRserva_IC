using Microsoft.Extensions.Logging;
using Moq;
using Reservas.Application.Dto.Reserva;
using Reservas.Application.Services;
using Reservas.Application.UseCases.Command.Reservas.CrearReserva;
using Reservas.Domain.Event.Reservas;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Moq.It;

namespace Reservas.Test.Application.UserCases.Handler {
    public class CrearReservaHandler_Tests {
        private readonly Mock<ReservaRepositories> reservaRepository;
        private readonly Mock<ILogger<CrearReservaHandler>> logger;
        private readonly Mock<IReservaService> reservaService;
        private readonly Mock<IReservaFactory> reservaFactory;
        private readonly Mock<IUnitOfWorks> unitOfWork;
        private Reserva reservaTest;
        private int idReservaTest = 5;
        private Guid guidTest = Guid.NewGuid();
        private DetalleReservaDto detalleReservaTest = new DetalleReservaDto();


        public CrearReservaHandler_Tests() {
            reservaRepository = new Mock<ReservaRepositories>();
            logger = new Mock<ILogger<CrearReservaHandler>>();
            reservaService = new Mock<IReservaService>();
            reservaFactory = new Mock<IReservaFactory>();
            unitOfWork = new Mock<IUnitOfWorks>();
            reservaTest = new ReservaFactory().Create(idReservaTest);
        }

        [Fact]
        public void CrearReservaHandler_HandleCorrectly() {
            reservaService.Setup(reservaService => reservaService.GenerarIdReservaAsync()).Returns(Task.FromResult(idReservaTest));
            reservaFactory.Setup(reservaFactory => reservaFactory.Create(idReservaTest)).Returns(reservaTest);
            var objHandler = new CrearReservaHandler(
                reservaRepository.Object,
                logger.Object,
                reservaService.Object,
                reservaFactory.Object,
                unitOfWork.Object
            );
            var objRequest = new CrearReservaCommand(
                detalleReservaTest
            );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);

            reservaRepository.Verify(mock => mock.CreateAsync(IsAny<Reserva>()), Times.Once);
            unitOfWork.Verify(mock => mock.Commit(), Times.Once);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)reservaTest.DomainEvents;
            Assert.Equal(4, domainEventList.Count);
            Assert.IsType<ReservaRealizada>(domainEventList[1]);
        }
        [Fact]
        public void CrearReservaHandler_Handle_Fail() {
            // Failing by returning null values
            var objHandler = new CrearReservaHandler(
               reservaRepository.Object,
               logger.Object,
               reservaService.Object,
               reservaFactory.Object,
               unitOfWork.Object
           );
            var objRequest = new CrearReservaCommand(
              detalleReservaTest
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear reserva"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
