namespace ChallengeOdontoprevSprint3.Repository.Interface
{
    public interface ISimpleFactory
    {
   
        IPacienteRepository CreatePacienteService();
        IClinicaRepository CreateClinicaService();
        IDentistaRepository CreateDentistaService();
        IContasReceberRepository CreateContasReceberService();
        IContasPagarRepository CreateContasPagarService();
        IAgendamentoRepository CreateAgendamentoService();
        IFraudeRepository CreateFraudeService();
        ITabelaPrecoRepository CreateTabelaPrecoService();



    }
}
