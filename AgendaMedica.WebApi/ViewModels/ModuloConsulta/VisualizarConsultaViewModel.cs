﻿using AgendaMedicaApi.ViewModels.ModuloMedico;

namespace AgendaMedicaApi.ViewModels.ModuloConsulta
{
    public class VisualizarConsultaViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public ListarMedicoViewModel Medico { get; set; }

        public VisualizarConsultaViewModel()
        {
            Medico = new ListarMedicoViewModel();
        }
    }
}