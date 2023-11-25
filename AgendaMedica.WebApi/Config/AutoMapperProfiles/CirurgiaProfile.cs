using AutoMapper;
using AgendaMedicaApi.ViewModels.ModuloCirurgia;
using AgendaMedica.Dominio.ModuloCirurgia;
using AgendaMedica.Dominio.ModuloMedico;

namespace AgendaMedica.WebApi.Config.AutoMapperProfiles
{
    public class CirurgiaProfile : Profile
    {
        public CirurgiaProfile()
        {
            CreateMap<Cirurgia, ListarCirurgiaViewModel>();

            CreateMap<Cirurgia, VisualizarCirurgiaViewModel>()
                .ForMember(destino => destino.HoraInicio, opt => opt.MapFrom(origem => origem.HoraInicio.ToString(@"hh\:mm")))
                .ForMember(destino => destino.HoraTermino, opt => opt.MapFrom(origem => origem.HoraTermino.ToString(@"hh\:mm")))
                .ForMember(destino => destino.Medicos, opt => opt.Ignore());

            CreateMap<FormsCirurgiaViewModel, Cirurgia>()
                .ForMember(destino => destino.HoraInicio, opt => opt.MapFrom(origem => origem.HoraInicio.ToString(@"hh\:mm")))
                .ForMember(destino => destino.HoraTermino, opt => opt.MapFrom(origem => origem.HoraTermino.ToString(@"hh\:mm")))
                .ForMember(destino => destino.ListaMedicos, opt => opt.Ignore())
                .AfterMap<FormsCirurgiaMappingAction>();
        }
    }

    public class FormsCirurgiaMappingAction : IMappingAction<FormsCirurgiaViewModel, Cirurgia>
    {
        private readonly IRepositorioMedico repositorioMedico;

        public FormsCirurgiaMappingAction(IRepositorioMedico repositorioMedico)
        {
            this.repositorioMedico = repositorioMedico;
        }

        public void Process(FormsCirurgiaViewModel source, Cirurgia destination, ResolutionContext context)
        {
            destination.ListaMedicos.AddRange(repositorioMedico.SelecionarMuitos(source.MedicosSelecionados));
        }
    }
}
