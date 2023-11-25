using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Infra.Orm.ModuloCirurgia;
using AgendaMedica.Infra.Orm.ModuloConsulta;
using AgendaMedica.Infra.Orm.ModuloMedico;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Infra.Orm.Compartilhado
{
    public class eAgendaMedicaDbContext : DbContext, IContextoPersistencia
    {
        public eAgendaMedicaDbContext(DbContextOptions options) : base(options)
        {
        }

        public async Task<bool> GravarAsync()
        {
            await SaveChangesAsync();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorCirurgiaOrm());

            modelBuilder.ApplyConfiguration(new MapeadorConsultaOrm());

            modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());

            base.OnModelCreating(modelBuilder);
        }
    }
}
