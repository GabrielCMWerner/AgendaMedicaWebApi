using AgendaMedica.Dominio.ModuloCirurgia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Infra.Orm.ModuloCirurgia
{
    public class MapeadorCirurgiaOrm : IEntityTypeConfiguration<Cirurgia>
    {
        public void Configure(EntityTypeBuilder<Cirurgia> builder)
        {
            builder.ToTable("TBCirurgia");

            builder.Property(x => x.Id)
               .ValueGeneratedNever();

            builder.Property(x => x.Titulo)
                .IsRequired();

            builder.Property(x => x.HoraInicio)
                .IsRequired();

            builder.Property(x => x.HoraTermino)
                .IsRequired();
        }
    }
}