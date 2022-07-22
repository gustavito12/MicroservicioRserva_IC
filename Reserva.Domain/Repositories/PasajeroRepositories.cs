using Reservas.Domain.Model.Pasajeros;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface PasajeroRepositories : IRepository<Pasajero, Guid>
    {
        
    }
}
