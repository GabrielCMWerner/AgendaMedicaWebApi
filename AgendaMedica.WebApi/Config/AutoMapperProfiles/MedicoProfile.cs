using AutoMapper;
using AgendaMedicaApi.ViewModels.ModuloMedico;
using AgendaMedica.Dominio.ModuloMedico;

namespace AgendaMedica.WebApi.Config.AutoMapperProfiles
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<Medico, ListarMedicoViewModel>();
            CreateMap<Medico, VisualizarMedicoViewModel>();
            CreateMap<FormsMedicoViewModel, Medico>();
            CreateMap<ListarMedicoViewModel, Medico>();
            CreateMap<Medico, ListarMedicoViewModel>();
        }
    }
}