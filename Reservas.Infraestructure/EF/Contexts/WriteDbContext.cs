using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Event.Reservas;
using Reservas.Domain.Model.Reservas;
using Reservas.Infraestructure.EF.Config.WriteConfig;
using Reservas.Infraestructure.EF.ReadModel;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {

        public virtual DbSet<Reserva> Reserva { set; get; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var reservaConfig = new ReservaWriteConfig();
            modelBuilder.ApplyConfiguration<Reserva>(reservaConfig);
            modelBuilder.ApplyConfiguration<DetalleReserva>(reservaConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<ReservaRealizada>();


        }
    }
}
