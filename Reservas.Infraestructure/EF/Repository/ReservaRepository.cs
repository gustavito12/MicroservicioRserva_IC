using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using ShareKernel.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservas.Infraestructure.EF.Contexts;

namespace Reservas.Infraestructure.EF.Repository
{
    public class ReservaRepository : ReservaRepositories
    {

        public readonly DbSet<Reserva> _reservas;

        public ReservaRepository(WriteDbContext context)
        {
            _reservas = context.Reserva;
        }
        public async Task CreateAsync(Reserva obj)
        {
            await _reservas.AddAsync(obj);
        }

        public async Task<Reserva> FindByIdAsync(Guid id)
        {
            return await _reservas.Include("_detalle")
                        .SingleAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Reserva obj)
        {
            _reservas.Update(obj);

            return Task.CompletedTask; 
        }
    }
}
