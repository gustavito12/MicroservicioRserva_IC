using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reservas.ValueObjects
{
   public record LimiteTiempoPago : ValueObject
    {
        public int TiempoTranscurrido { get; }
        public LimiteTiempoPago(int _tiempoTranscurrido)
        {
            if (_tiempoTranscurrido > 2)
            {
                throw new BussinessRuleValidationException("Expiro el Tiempo de Reserva, se cancela la reserva");
            }
            TiempoTranscurrido = _tiempoTranscurrido;
        }

        public static implicit operator int(LimiteTiempoPago _tiempoTranscurrido)
        {
            return _tiempoTranscurrido.TiempoTranscurrido;
        }

        public static implicit operator LimiteTiempoPago(int _tiempoTranscurrido)
        {
            return new LimiteTiempoPago(_tiempoTranscurrido);
        }
    }
}
