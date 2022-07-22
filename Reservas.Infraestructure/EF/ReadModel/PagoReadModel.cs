using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class PagoReadModel
    {
        public int TipoCombrobante { get; private set; }
        public DateTime FechaPago { get; private set; }
        public int TipoPago { get; private set; }
        public string NumFactura { get; private set; }
        public decimal NumRecibo { get; private set; }
        public decimal TotalPagado { get; private set; }
    
    }
}
