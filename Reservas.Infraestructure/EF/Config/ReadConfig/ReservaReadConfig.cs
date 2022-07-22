using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EF.ReadModel;

namespace Reservas.Infraestructure.EF.Config.ReadConfig
{
    public class ReservaReadConfig : IEntityTypeConfiguration<ReservaReadModel>, IEntityTypeConfiguration<DetalleReservaReadModel>
    {
        public void Configure(EntityTypeBuilder<ReservaReadModel> builder)
        {
            // Aqui van todos los campos del modelo
            builder.ToTable("Reserva");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.IdReserva)
                   .HasColumnName("idReserva")
                   .HasColumnType("int");

            builder.HasMany(x => x.Detalle)
                    .WithOne(x => x.Reserva);

            builder.Ignore("_domainEvents");

        }

        public void Configure(EntityTypeBuilder<DetalleReservaReadModel> builder)
        {
            builder.ToTable("DetalleReserva");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FechaReserva)
                   .HasColumnName("fechaReserva")
                   .HasColumnType("DateTime");

            builder.Property(x => x.Importe)
                   .HasColumnName("importe")
                   .HasColumnType("decimal")
                   .HasPrecision(12, 2);

            builder.Property(x => x.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int");

            builder.Property(x => x.NumTicket)
                   .HasColumnName("numTicket")
                   .HasColumnType("int");
        }
    }
}
