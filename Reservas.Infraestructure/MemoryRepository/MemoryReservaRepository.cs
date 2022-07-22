using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.MemoryRepository
{
    public class MemoryReservaRepository : ReservaRepositories
    {
        private readonly MemoryDatabase _database;

        public MemoryReservaRepository(MemoryDatabase database)
        {
            _database = database;
        }

        public Task CreateAsync(Reserva obj)
        {
            _database.Reservas.Add(obj);
            return Task.CompletedTask;
        }

        public Task<Reserva> FindByIdAsync(Guid id)
        {
            return Task.FromResult(_database.Reservas.FirstOrDefault(x => x.Id == id));
        }

        public Task UpdateAsync(Reserva obj)
        {
            return Task.CompletedTask;
        }
    }
}
