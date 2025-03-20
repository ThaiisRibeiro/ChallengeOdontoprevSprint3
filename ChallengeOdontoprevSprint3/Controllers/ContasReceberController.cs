using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasReceberController : ControllerBase
    {

        private readonly ISimpleFactory _IContasReceberRepository;
        private static int _id = 0; // Controla o ID

        public ContasReceberController(ISimpleFactory IContasReceberRepository)
        {
            _IContasReceberRepository = IContasReceberRepository;
        }

        // GET: api/agendamento
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var ContasReceberRepository = _IContasReceberRepository.CreateContasReceberService();
            return Ok(await ContasReceberRepository.Listar());
        }

        // GET: api/agendamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var ContasReceberRepository = _IContasReceberRepository.CreateContasReceberService();
            var contasreceber = await ContasReceberRepository.ObterPorId(id);
            if (contasreceber == null)
            {
                return NotFound(new { message = "Contas a Receber não encontrada." });
            }
            return Ok(contasreceber);
        }

        // POST: api/agendamento/adicionar
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] ContasReceber contasreceber)
        {
            var ContasReceberRepository = _IContasReceberRepository.CreateContasReceberService();
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

          //  contasreceber.id_conta_receber = ++_id;
            await ContasReceberRepository.Adcionar(contasreceber);

            return Ok(new { message = "contas a receber cadastrada!", data = contasreceber });
        }

        // PUT: api/agendamento/atualizar/{id}
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] ContasReceber contasreceber)
        {
            var ContasReceberRepository = _IContasReceberRepository.CreateContasReceberService();
            if (id != contasreceber.id_conta_receber)
            {
                return BadRequest(new { message = "O ID informado não corresponde a contas a receber." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await ContasReceberRepository.Atualizar(contasreceber);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar a conta a receber." });
            }

            return Ok(new { message = "conta a receber atualizada!", data = contasreceber });
        }

        // DELETE: api/agendamento/excluir/{id}
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var ContasReceberRepository = _IContasReceberRepository.CreateContasReceberService();
            var contasreceber = await ContasReceberRepository.ObterPorId(id);
            if (contasreceber == null)
            {
                return NotFound(new { message = "conta a receber não encontrado." });
            }

            await ContasReceberRepository.Excluir(contasreceber);

            return Ok(new { message = "conta a receber excluída com sucesso!" });
        }
    }
}
