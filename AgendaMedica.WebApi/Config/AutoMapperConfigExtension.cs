﻿using AgendaMedica.WebApi.Config.AutoMapperProfiles;

namespace Agenda.WebApi.Config.AutomapperConfig
{
    public static class AutoMapperConfigExtension
    {
        public static void ConfigurarAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile<CirurgiaProfile>();
                opt.AddProfile<ConsultaProfile>();
                opt.AddProfile<MedicoProfile>();
            });
        }
    }
}
