using Reservas.Domain.Event.Pasajeros;
using Reservas.Domain.Model.Pasajeros.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Pasajeros
{
    public class Pasajero : AggregateRoot<Guid>
    {
        
        
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public CantidadCI NumeroDocumento { get; set; }
        public CantidadNIT NITPasajero { get; set; }

        public Pasajero(string apellidoPaterno, string apellidoMaterno, string nombres, DateTime fechaNacimiento, string direccion, string telefono, string numeroDocumento, string nITPasajero)
        {
            Id = Guid.NewGuid();
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Nombres = nombres;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Telefono = telefono;
            NumeroDocumento = numeroDocumento;
            NITPasajero = nITPasajero;
        }

        public void RegistrarPasajero()
        {
            var evento = new PasajeroRegistrado(Id, ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Direccion, Telefono, NumeroDocumento, NITPasajero);
            AddDomainEvent(evento);
        }

    }
}
