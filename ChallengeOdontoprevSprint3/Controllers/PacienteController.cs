using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ISimpleFactory _IPacienteRepository;
        private static int _id = 0; // Controla o ID

        public PacienteController(ISimpleFactory IPacienteRepository)
        {
            _IPacienteRepository = IPacienteRepository;
        }

        // GET: api/agendamento
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var PacienteRepository = _IPacienteRepository.CreatePacienteService();
            return Ok(await PacienteRepository.Listar());
        }

        // GET: api/agendamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var PacienteRepository = _IPacienteRepository.CreatePacienteService();
            var paciente = await PacienteRepository.ObterPorId(id);
            if (paciente == null)
            {
                return NotFound(new { message = "Paciente não encontrado." });
            }
            return Ok(paciente);
        }

        // POST: api/agendamento/adicionar
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Paciente paciente)
        {
            var PacienteRepository = _IPacienteRepository.CreatePacienteService();
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

           // paciente.id_paciente = ++_id;
            await PacienteRepository.Adcionar(paciente);

            return Ok(new { message = "Paciente cadastrado!", data = paciente });
        }

        // PUT: api/agendamento/atualizar/{id}
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Paciente paciente)
        {
            var PacienteRepository = _IPacienteRepository.CreatePacienteService();
            if (id != paciente.id_paciente)
            {
                return BadRequest(new { message = "O ID informado não corresponde o Paciente." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await PacienteRepository.Atualizar(paciente);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar o Paciente." });
            }

            return Ok(new { message = "paciente atualizado!", data = paciente });
        }

        // DELETE: api/agendamento/excluir/{id}
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var PacienteRepository = _IPacienteRepository.CreatePacienteService();
            var paciente = await PacienteRepository.ObterPorId(id);
            if (paciente == null)
            {
                return NotFound(new { message = "paciente não encontrado." });
            }

            await PacienteRepository.Excluir(paciente);

            return Ok(new { message = "paciente excluído com sucesso!" });
        }
    }
}
