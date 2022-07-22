using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reservas.ValueObjects
{
    public record MinimoPago : ValueObject
    {
        public decimal Importe { get; }
        public MinimoPago(decimal _importe)
        {
            if (_importe < 0)
            {
                throw new BussinessRuleValidationException("El importe de Vuelo no puede ser menor a 0.");
            }
            Importe = _importe;
        }

        public static implicit operator decimal(MinimoPago _importe)
        {
            return _importe.Importe;
        }

        public static implicit operator MinimoPago(decimal _importe)
        {
            return new MinimoPago(_importe);
        }
    }
}
