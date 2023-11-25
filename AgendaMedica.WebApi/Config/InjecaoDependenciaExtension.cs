using AgendaMedica.Aplicacao.ModuloCirurgia;
using AgendaMedica.Aplicacao.ModuloConsulta;
using AgendaMedica.Aplicacao.ModuloMedico;
using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloCirurgia;
using AgendaMedica.Dominio.ModuloConsulta;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Infra.Orm.Compartilhado;
using AgendaMedica.Infra.Orm.ModuloCirurgia;
using AgendaMedica.Infra.Orm.ModuloConsulta;
using AgendaMedica.Infra.Orm.ModuloMedico;
using AgendaMedica.WebApi.Config.AutoMapperProfiles;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.WebApi.Config
{
    public static class InjecaoDependenciaConfigExtension
    {
        public static void ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<IContextoPersistencia, eAgendaMedicaDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            services.AddTransient<IRepositorioMedico, RepositorioMedicoOrm>();
            services.AddTransient<ServicoMedico>();

            services.AddScoped<IRepositorioConsulta, RepositorioConsultaOrm>();
            services.AddTransient<ServicoConsulta>();

            services.AddScoped<IRepositorioCirurgia, RepositorioCirurgiaOrm>();
            services.AddTransient<ServicoCirurgia>();

            services.AddTransient<FormsCirurgiaMappingAction>();
        }
    }
}