using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasPagarController : ControllerBase
    {
        private readonly ISimpleFactory _IContasPagarRepository;
        private static int _id = 0; // Controla o ID

        public ContasPagarController(ISimpleFactory IContasPagarRepository)
        {
            _IContasPagarRepository = IContasPagarRepository;
        }

        // GET: api/agendamento
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var ContasPagarRepository = _IContasPagarRepository.CreateContasPagarService();
            return Ok(await ContasPagarRepository.Listar());
        }

        // GET: api/agendamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var ContasPagarRepository = _IContasPagarRepository.CreateContasPagarService();
            var contaspagar = await ContasPagarRepository.ObterPorId(id);
            if (contaspagar == null)
            {
                return NotFound(new { message = "Contas a Pagar não encontrada." });
            }
            return Ok(contaspagar);
        }

        // POST: api/agendamento/adicionar
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] ContasPagar contaspagar)
        {
            var ContasPagarRepository = _IContasPagarRepository.CreateContasPagarService();
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

           // contaspagar.id_conta_pagar = ++_id;
            await ContasPagarRepository.Adcionar(contaspagar);

            return Ok(new { message = "contas a pagar cadastrada!", data = contaspagar });
        }

        // PUT: api/agendamento/atualizar/{id}
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] ContasPagar contaspagar)
        {
            var ContasPagarRepository = _IContasPagarRepository.CreateContasPagarService();
            if (id != contaspagar.id_conta_pagar)
            {
                return BadRequest(new { message = "O ID informado não corresponde a contas a pagar." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await ContasPagarRepository.Atualizar(contaspagar);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar a conta a pagar." });
            }

            return Ok(new { message = "conta a pagar atualizada!", data = contaspagar });
        }

        // DELETE: api/agendamento/excluir/{id}
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var ContasPagarRepository = _IContasPagarRepository.CreateContasPagarService();
            var contaspagar = await ContasPagarRepository.ObterPorId(id);
            if (contaspagar == null)
            {
                return NotFound(new { message = "conta a pagar não encontrado." });
            }

            await ContasPagarRepository.Excluir(contaspagar);

            return Ok(new { message = "conta a pagar excluída com sucesso!" });
        }
    }
}

