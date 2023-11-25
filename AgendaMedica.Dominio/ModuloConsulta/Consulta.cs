using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloMedico;

namespace AgendaMedica.Dominio.ModuloConsulta
{
    public class Consulta : Entidade
    {

        public string Titulo { get; set; }

        public Medico Medico { get; set; }

        public Guid MedicoId { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraTermino { get; set; }

        public Consulta()
        {
        }

        public Consulta(string titulo, Medico medico, Guid medicoId, TimeSpan horaInicio)
        {
            Titulo = titulo;
            Medico = medico;
            MedicoId = medicoId;
            HoraInicio = horaInicio;
        }
    }
}
