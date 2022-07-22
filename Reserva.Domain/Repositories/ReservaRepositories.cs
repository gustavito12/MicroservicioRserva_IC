using Reservas.Domain.Model.Reservas;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface ReservaRepositories : IRepository<Reserva, Guid>
    {
        Task UpdateAsync(Reserva obj);
    }
}
