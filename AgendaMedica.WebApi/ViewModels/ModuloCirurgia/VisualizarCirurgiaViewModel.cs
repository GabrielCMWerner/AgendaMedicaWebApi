using AgendaMedicaApi.ViewModels.ModuloMedico;

namespace AgendaMedicaApi.ViewModels.ModuloCirurgia
{
    public class VisualizarCirurgiaViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public List<ListarMedicoViewModel> Medicos { get; set; }

        public VisualizarCirurgiaViewModel()
        {
            Medicos = new List<ListarMedicoViewModel>();
        }
    }
}