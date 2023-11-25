using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloCirurgia;
using AgendaMedica.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Infra.Orm.ModuloCirurgia
{
    public class RepositorioCirurgiaOrm : RepositorioBase<Cirurgia>, IRepositorioCirurgia
    {
        public RepositorioCirurgiaOrm(IContextoPersistencia ctx) : base(ctx)
        {
        }

        public override Cirurgia SelecionarPorId(Guid id)
        {
            return registros.Include(x => x.ListaMedicos).SingleOrDefault(x => x.Id == id);
        }

        public override async Task<Cirurgia> SelecionarPorIdAsync(Guid id)
        {
            return await registros.Include(x => x.ListaMedicos).SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<Cirurgia>> SelecionarTodosAsync()
        {
            return await registros.Include(x => x.ListaMedicos).ToListAsync();
        }
    }
}