﻿using AutoMapper;
using AgendaMedicaApi.ViewModels.ModuloConsulta;
using AgendaMedica.Dominio.ModuloConsulta;

namespace AgendaMedica.WebApi.Config.AutoMapperProfiles
{
    public class ConsultaProfile : Profile
    {
        public ConsultaProfile()
        {
            CreateMap<Consulta, ListarConsultaViewModel>()
                .ForMember(destino => destino.HoraInicio, opt => opt.MapFrom(origem => origem.HoraInicio.ToString(@"hh\:mm")))
                .ForMember(destino => destino.HoraTermino, opt => opt.MapFrom(origem => origem.HoraTermino.ToString(@"hh\:mm")))
                .ForMember(destino => destino.NomeMedico, opt => opt.MapFrom(origem => origem.Medico.Nome));

            CreateMap<Consulta, VisualizarConsultaViewModel>()
                .ForMember(destino => destino.HoraInicio, opt => opt.MapFrom(origem => origem.HoraInicio.ToString(@"hh\:mm")))
                .ForMember(destino => destino.HoraTermino, opt => opt.MapFrom(origem => origem.HoraTermino.ToString(@"hh\:mm")))
                .ForMember(destino => destino.Medico, opt => opt.MapFrom(origem => origem.Medico));

            CreateMap<FormsConsultaViewModel, Consulta>()
                .ForMember(destino => destino.HoraInicio, opt => opt.MapFrom(origem => origem.HoraInicio.ToString(@"hh\:mm")))
                .ForMember(destino => destino.HoraTermino, opt => opt.MapFrom(origem => origem.HoraTermino.ToString(@"hh\:mm")));

            CreateMap<Consulta, FormsConsultaViewModel>()
                 .ForMember(destino => destino.HoraInicio, opt => opt.MapFrom(origem => origem.HoraInicio.ToString(@"hh\:mm")))
                .ForMember(destino => destino.HoraTermino, opt => opt.MapFrom(origem => origem.HoraTermino.ToString(@"hh\:mm")));
        }
    }
}
