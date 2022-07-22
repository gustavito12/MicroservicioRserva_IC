using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.Pasajeros;
using Reservas.Domain.Model.Reservas;
using System;

namespace ReservaCOnsolaUI
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Pasajero objPasajero = new Pasajero("VARGAS", "MONTEVILLA", "GILMAR GUSTAVO", DateTime.Now, "CALLE TIAHUANACU", "60372816", "6878222", "123465789");
            objPasajero.RegistrarPasajero();


            Reserva objReserva = new Reserva();
            objReserva.CargaReservaDetalle(DateTime.Now,500.5m,1,123);
            objReserva.CargaReservaPago(1,DateTime.Now,1,"123456",52222.0m,250.5m);
            objReserva.RegistrarReserva();

        }
    }
}
