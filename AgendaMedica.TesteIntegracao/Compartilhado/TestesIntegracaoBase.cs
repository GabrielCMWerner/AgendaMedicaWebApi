﻿
using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloCirurgia;
using AgendaMedica.Dominio.ModuloConsulta;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Infra.Orm.Compartilhado;
using AgendaMedica.Infra.Orm.ModuloCirurgia;
using AgendaMedica.Infra.Orm.ModuloConsulta;
using AgendaMedica.Infra.Orm.ModuloMedico;
using FizzWare.NBuilder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace AgendaMedica.TestesIntegracao.Compartilhado
{
    public class TestesIntegracaoBase
    {
        protected IRepositorioMedico repositorioMedico;
        protected IRepositorioConsulta repositorioConsulta;
        protected IRepositorioCirurgia repositorioCirurgia;

        protected IContextoPersistencia contextoPersistencia;

        public TestesIntegracaoBase()
        {

            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new eAgendaMedicaDbContext(optionsBuilder.Options);

            dbContext.Database.Migrate();

            LimparTabelas();

            contextoPersistencia = dbContext;

            repositorioMedico = new RepositorioMedicoOrm(dbContext);
            repositorioConsulta = new RepositorioConsultaOrm(dbContext);
            repositorioCirurgia = new RepositorioCirurgiaOrm(dbContext);


            BuilderSetup.SetCreatePersistenceMethod<Medico>((Medico) =>
            {
                Task.Run(async () =>
                {
                    await repositorioMedico.InserirAsync(Medico);
                    await contextoPersistencia.GravarAsync();
                }).GetAwaiter().GetResult();
            });

            BuilderSetup.SetCreatePersistenceMethod<Consulta>((Consulta) =>
            {
                Task.Run(async () =>
                {
                    await repositorioConsulta.InserirAsync(Consulta);
                    await contextoPersistencia.GravarAsync();
                }).GetAwaiter().GetResult();
            });

            BuilderSetup.SetCreatePersistenceMethod<Cirurgia>((Cirurgia) =>
            {
                Task.Run(async () =>
                {
                    await repositorioCirurgia.InserirAsync(Cirurgia);
                    await contextoPersistencia.GravarAsync();
                }).GetAwaiter().GetResult();
            });
        }

        protected static void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"

                DELETE FROM [DBO].[TBMEDICO_TBCIRURGIA]

                DELETE FROM [DBO].[TBCIRURGIA]
                
                DELETE FROM [DBO].[TBCONSULTA]

                DELETE FROM [DBO].[TBMEDICO];";

            SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }

        protected static string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            return connectionString;
        }
    }
}