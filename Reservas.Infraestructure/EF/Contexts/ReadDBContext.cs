using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Event.Reservas;
using Reservas.Infraestructure.EF.Config.ReadConfig;
using Reservas.Infraestructure.EF.ReadModel;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Contexts
{
    public class ReadDBContext : DbContext
    {

        public virtual DbSet<ReservaReadModel> Reserva { set;  get; }
        
        public ReadDBContext(DbContextOptions<ReadDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var reservaConfig = new ReservaReadConfig();
            modelBuilder.ApplyConfiguration<ReservaReadModel>(reservaConfig);
            modelBuilder.ApplyConfiguration<DetalleReservaReadModel>(reservaConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<ReservaRealizada>();
        }
    }
}
