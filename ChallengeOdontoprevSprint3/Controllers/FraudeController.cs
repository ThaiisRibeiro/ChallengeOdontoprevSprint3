using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FraudeController : ControllerBase
    {
        private readonly ISimpleFactory _IFraudeRepository;
        private static int _id = 0; // Controla o ID

        public FraudeController(ISimpleFactory IFraudeRepository)
        {
            _IFraudeRepository = IFraudeRepository;
        }

        // GET: api/agendamento
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var FraudeRepository = _IFraudeRepository.CreateFraudeService();
            return Ok(await FraudeRepository.Listar());
        }

        // GET: api/agendamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var FraudeRepository = _IFraudeRepository.CreateFraudeService();
            var fraude = await FraudeRepository.ObterPorId(id);
            if (fraude == null)
            {
                return NotFound(new { message = "Fraude não encontrada." });
            }
            return Ok(fraude);
        }

        // POST: api/agendamento/adicionar
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Fraude fraude)
        {
            var FraudeRepository = _IFraudeRepository.CreateFraudeService();
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

           // fraude.id_fraude = ++_id;
            await FraudeRepository.Adcionar(fraude);

            return Ok(new { message = "Fraude cadastrada!", data = fraude });
        }

        // PUT: api/agendamento/atualizar/{id}
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Fraude fraude)
        {
            var FraudeRepository = _IFraudeRepository.CreateFraudeService();
            if (id != fraude.id_fraude)
            {
                return BadRequest(new { message = "O ID informado não corresponde a Fraude." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await FraudeRepository.Atualizar(fraude);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar a Fraude." });
            }

            return Ok(new { message = "fraude atualizada!", data = fraude });
        }

        // DELETE: api/agendamento/excluir/{id}
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var FraudeRepository = _IFraudeRepository.CreateFraudeService();
            var fraude = await FraudeRepository.ObterPorId(id);
            if (fraude == null)
            {
                return NotFound(new { message = "fraude não encontrada." });
            }

            await FraudeRepository.Excluir(fraude);

            return Ok(new { message = "fraude excluída com sucesso!" });
        }
    }
}

