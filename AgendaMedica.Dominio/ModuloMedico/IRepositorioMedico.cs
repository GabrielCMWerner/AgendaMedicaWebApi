using AgendaMedica.Dominio.Compartilhado;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public interface IRepositorioMedico : IRepositorioBase<Medico>
    {
        public List<Medico> SelecionarMuitos(List<Guid> medicos);

        public List<Guid> SelecionarMuitos(List<Medico> medicos);
    }
}
