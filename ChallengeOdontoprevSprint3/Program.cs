
using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using ChallengeOdontoprevSprint3.Repository;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3
{
    public class Program
    {
        public static void Main(string[] args)
        {
         
            var builder = WebApplication.CreateBuilder(args);

            var stringConexao = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=;Password=;";

            builder.Services.AddDbContext<Context>
                (options => options.UseOracle(stringConexao));

            //1

            /*
            builder.Services.AddScoped<IPacienteRepository, RepositoryPaciente>();


            builder.Services.AddScoped<IAgendamentoRepository, RepositoryAgendamento>();
            builder.Services.AddScoped<IClinicaRepository, RepositoryClinica>();
            builder.Services.AddScoped<IContasPagarRepository, RepositoryContasPagar>();
            builder.Services.AddScoped<IContasReceberRepository, RepositoryContasReceber>();
            builder.Services.AddScoped<IDentistaRepository, RepositoryDentista>();
            builder.Services.AddScoped<IFraudeRepository, RepositoryFraude>();
            builder.Services.AddScoped<ITabelaPrecoRepository, RepositoryTabelaPreco>();
            */
            builder.Services.AddScoped<ISimpleFactory, RepositorySimpleFactory>();  //Injecao de Dependencia com o Simple Factory

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
