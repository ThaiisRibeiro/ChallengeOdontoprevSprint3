using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.EntityFrameworkCore;
namespace ChallengeOdontoprevSprint3.Repository
{
    public class RepositorySimpleFactory : ISimpleFactory
    {

        


        public IPacienteRepository CreatePacienteService() => new RepositoryPaciente();
            public IClinicaRepository CreateClinicaService() => new RepositoryClinica();
            public IDentistaRepository CreateDentistaService() => new RepositoryDentista();
            public IContasReceberRepository CreateContasReceberService() => new RepositoryContasReceber();
            public IContasPagarRepository CreateContasPagarService() => new RepositoryContasPagar();
            public IAgendamentoRepository CreateAgendamentoService() => new RepositoryAgendamento();
            public IFraudeRepository CreateFraudeService() => new RepositoryFraude();
            public ITabelaPrecoRepository CreateTabelaPrecoService() => new RepositoryTabelaPreco();
        /*
        public IContasReceberRepository CreateContasReceberService()
        {
            throw new NotImplementedException();
        }

        public IContasPagarRepository CreateContasPagarService()
        {
            throw new NotImplementedException();
        }

        IAgendamentoRepository ISimpleFactory.CreateAgendamentoService()
        {
            throw new NotImplementedException();
        }

        IFraudeRepository ISimpleFactory.CreateFraudeService()
        {
            throw new NotImplementedException();
        }
        */
    }
}
