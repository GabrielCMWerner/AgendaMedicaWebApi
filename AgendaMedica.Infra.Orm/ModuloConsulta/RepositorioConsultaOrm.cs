using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloConsulta;
using AgendaMedica.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Infra.Orm.ModuloConsulta
{
    public class RepositorioConsultaOrm : RepositorioBase<Consulta>, IRepositorioConsulta
    {
        public RepositorioConsultaOrm(IContextoPersistencia ctx) : base(ctx)
        {
        }
        public async Task<List<Consulta>> SelecionarConsultasMedico(Guid id)
        {
            return await registros.Where(x => x.Medico.Id == id).ToListAsync();
        }

        public async Task<bool> ExisteConsultaNesseHorarioPorMedicoId(Guid medicoId, TimeSpan horaInicio, TimeSpan horaTermino, DateTime data)
        {
            return await registros.AnyAsync(x => x.MedicoId == medicoId &&
            (((horaInicio >= x.HoraInicio && horaInicio <= x.HoraTermino) ||
                (horaTermino >= x.HoraInicio && horaTermino <= x.HoraTermino)) ||
                (x.HoraInicio >= horaInicio && x.HoraTermino <= horaTermino)
                 && data.Date == x.Data.Date));
        }

        public async Task<bool> ExisteConsultaNesseHorarioPorMedicoId(Consulta consulta)
        {
            return await registros.AnyAsync(x => x.MedicoId == consulta.MedicoId && ((consulta.HoraInicio >= x.HoraInicio && consulta.HoraInicio <= x.HoraTermino) ||
            (consulta.HoraTermino >= x.HoraInicio && consulta.HoraTermino <= x.HoraTermino)) && consulta.Data.Date == x.Data.Date);
        }

        public override async Task<Consulta> SelecionarPorIdAsync(Guid id)
        {
            return await registros.Include(x => x.Medico)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<Consulta>> SelecionarTodosAsync()
        {
            return await registros.Include(x => x.Medico).ToListAsync();
        }
    }
}
