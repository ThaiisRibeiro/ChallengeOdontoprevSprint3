using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class AgendamentoController : ControllerBase
        {
            private readonly ISimpleFactory _IAgendamentoRepository;
            private static int _id = 0; // Controla o ID

            public AgendamentoController(ISimpleFactory IAgendamentoRepository)
            {
                _IAgendamentoRepository = IAgendamentoRepository;
            }

            // GET: api/agendamento
            [HttpGet]
            public async Task<ActionResult> Index()
        {
            var AgendamentoRepository = _IAgendamentoRepository.CreateAgendamentoService();
            return Ok(await AgendamentoRepository.Listar());
            }

            // GET: api/agendamento/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult> ObterPorId(int id)
        {
            var AgendamentoRepository = _IAgendamentoRepository.CreateAgendamentoService();
            var agendamento = await AgendamentoRepository.ObterPorId(id);
                if (agendamento == null)
                {
                    return NotFound(new { message = "Agendamento não encontrado." });
                }
                return Ok(agendamento);
            }

            // POST: api/agendamento/adicionar
            [HttpPost("adicionar")]
            public async Task<ActionResult> Adicionar([FromBody] Agendamento agendamento)
        {
            var AgendamentoRepository = _IAgendamentoRepository.CreateAgendamentoService();
            if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Dados inválidos." });
                }

                //agendamento.id_agendamento = ++_id;
                await AgendamentoRepository.Adcionar(agendamento);

                return Ok(new { message = "Agendamento cadastrado!", data = agendamento });
            }

            // PUT: api/agendamento/atualizar/{id}
            [HttpPut("atualizar/{id}")]
            public async Task<ActionResult> Atualizar(int id, [FromBody] Agendamento agendamento)
        {
            var AgendamentoRepository = _IAgendamentoRepository.CreateAgendamentoService();
            if (id != agendamento.id_agendamento)
                {
                    return BadRequest(new { message = "O ID informado não corresponde ao agendamento." });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Dados inválidos." });
                }

                try
                {
                    await AgendamentoRepository.Atualizar(agendamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Conflict(new { message = "Erro de concorrência ao atualizar o agendamento." });
                }

                return Ok(new { message = "Agendamento atualizado!", data = agendamento });
            }

            // DELETE: api/agendamento/excluir/{id}
            [HttpDelete("excluir/{id}")]
            public async Task<ActionResult> Excluir(int id)
        {
            var AgendamentoRepository = _IAgendamentoRepository.CreateAgendamentoService();
            var agendamento = await AgendamentoRepository.ObterPorId(id);
                if (agendamento == null)
                {
                    return NotFound(new { message = "Agendamento não encontrado." });
                }

                await AgendamentoRepository.Excluir(agendamento);

                return Ok(new { message = "Agendamento excluído com sucesso!" });
            }
        }
    }


