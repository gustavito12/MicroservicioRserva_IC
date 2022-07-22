using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Pasajeros.ValueObjects
{
    public record CantidadNIT : ValueObject
    {
        public string Nit { get; }
        public CantidadNIT(string _nit)
        {
            CheckRule(new StringNotNullOrEmptyRule(_nit));
            if (_nit.Length < 10)
            {
                throw new BussinessRuleValidationException("No cumple con la cantidad minima de caracteres para el NIT.");
            }
            Nit = _nit;
        }

        public static implicit operator string(CantidadNIT _nit)
        {
            return _nit.Nit;
        }

        public static implicit operator CantidadNIT(string _nit)
        {
            return new CantidadNIT(_nit);
        }
    }
}
