using AgendaMedica.Dominio.Compartilhado;

namespace AgendaMedica.Dominio.ModuloConsulta
{
    public interface IRepositorioConsulta : IRepositorioBase<Consulta>
    {
        public Task<bool> ExisteConsultaNesseHorarioPorMedicoId(Consulta consulta);

        public Task<List<Consulta>> SelecionarConsultasMedico(Guid id);

        public Task<bool> ExisteConsultaNesseHorarioPorMedicoId(Guid medicoId, TimeSpan horaInicio, TimeSpan horaTermino, DateTime data);
    }
}
