using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloMedico;

namespace AgendaMedica.Dominio.ModuloCirurgia
{
    public class Cirurgia : Entidade
    {
        public string Titulo { get; set; }

        public DateTime Data { get; set; }

        public List<Medico> Medicos { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraTermino { get; set; }

        public Cirurgia()
        {
            Medicos = new List<Medico>();
        }

        public Cirurgia(string titulo, List<Medico> listaMedicos, TimeSpan horaInicio)
        {
            Titulo = titulo;
            Medicos = listaMedicos;
            HoraInicio = horaInicio;
        }

        public bool AdicionarMedico(Medico medico)
        {
            if (Medicos.Exists(x => x.Equals(medico)) == false)
            {
                medico.Cirurgias.Add(this);
                Medicos.Add(medico);

                return true;
            }

            return false;
        }

        public void RemoverMedico(Guid medicoId)
        {
            var medicoCirurgia = Medicos.Find(x => x.Id.Equals(medicoId));

            Medicos.Remove(medicoCirurgia);
        }
    }
}