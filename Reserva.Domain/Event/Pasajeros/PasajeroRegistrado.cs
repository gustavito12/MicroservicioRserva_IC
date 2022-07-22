using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Event.Pasajeros
{
    public record PasajeroRegistrado : DomainEvent
    {

        public Guid CodPasajero { get; }        
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NumeroDocumento { get; set; }
        public string NITPasajero { get; set; }

        public PasajeroRegistrado(Guid codPasajero,string apellidoPaterno, string apellidoMaterno, string nombres, DateTime fechaNacimiento, string direccion, string telefono, string numeroDocumento, string nITPasajero): base(DateTime.Now)
        {
            CodPasajero = codPasajero;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Nombres = nombres;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Telefono = telefono;
            NumeroDocumento = numeroDocumento;
            NITPasajero = nITPasajero;
        }
    }
}
