using Microsoft.EntityFrameworkCore;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Infra.Orm.Compartilhado;

namespace AgendaMedica.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            var novoMedico = new Medico();
            novoMedico.Nome = "Sergio";

            var optionsBuilder = new DbContextOptionsBuilder<AgendaMedicaDbContext>();

            optionsBuilder.UseSqlServer(@"");

            var dbContext = new AgendaMedicaDbContext(optionsBuilder.Options);

            dbContext.Medico.Add(novoMedico);

            dbContext.SaveChanges();

            
        }
    }
}