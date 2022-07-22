using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF
{
    public class UnitOfWork : IUnitOfWorks
    {

        private readonly WriteDbContext _context;

        public UnitOfWork(WriteDbContext context)
        {
            _context = context;   
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
