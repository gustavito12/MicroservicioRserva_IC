using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Model.Reservas.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Config.WriteConfig
{
    public class ReservaWriteConfig : IEntityTypeConfiguration<Reserva>, IEntityTypeConfiguration<DetalleReserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            // Aqui van todos los campos del modelo
            builder.ToTable("Reserva");

            builder.HasKey(x => x.Id);

            //var nroPedidoConverter = new ValueConverter(NumeroPedido, string > (
            //    x => x.value,
            //    x => new NumeroPedido(x)
            //    );

            builder.Property(x => x.IdReserva)
                   .HasColumnName("idReserva")
                   .HasColumnType("int");

        builder.HasMany(typeof(DetalleReserva), "_detalle");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.Detalle);
            builder.Ignore(x => x.DetallePago);
            builder.Ignore(x => x.IDPago);
            builder.Ignore(x => x.IDPasajero);
            builder.Ignore(x => x.VueloId);
        }

        public void Configure(EntityTypeBuilder<DetalleReserva> builder)
        {
            builder.ToTable("DetalleReserva");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FechaReserva)
                   .HasColumnName("fechaReserva")
                   .HasColumnType("DateTime");

            var importeConverter = new ValueConverter<MinimoPago, decimal>(
               importeValue => importeValue.Importe,
               importe => new MinimoPago(importe)
            );

            builder.Property(x => x.Importe)
                    .HasConversion(importeConverter)
                   .HasColumnName("importe")
                   .HasPrecision(12, 2);

            builder.Property(x => x.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int");

            builder.Property(x => x.NumTicket)
                   .HasColumnName("numTicket")
                   .HasColumnType("int");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
