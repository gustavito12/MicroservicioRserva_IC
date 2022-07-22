using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Pasajeros.ValueObjects
{
    public record CantidadCI : ValueObject
    {
        public string CI { get; }
        public CantidadCI(string _ci)
        {
            CheckRule(new StringNotNullOrEmptyRule(_ci));
            if (_ci.Length < 10)
            {
                throw new BussinessRuleValidationException("No cumple con la cantidad minima de caracteres para el CI.");
            }
            CI = _ci;
        }

        public static implicit operator string(CantidadCI _ci)
        {
            return _ci.CI;
        }

        public static implicit operator CantidadCI(string _ci)
        {
            return new CantidadCI(_ci);
        }
    }
}
