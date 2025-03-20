using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly ISimpleFactory _IClinicaRepository;
        private static int _id = 0; // Controla o ID

        public ClinicaController(ISimpleFactory IClinicaRepository)
        {
            _IClinicaRepository = IClinicaRepository;
        }

        // GET: api/agendamento
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var ClinicaRepository = _IClinicaRepository.CreateClinicaService();
            return Ok(await ClinicaRepository.Listar());
        }

        // GET: api/agendamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var ClinicaRepository = _IClinicaRepository.CreateClinicaService();
            var agendamento = await ClinicaRepository.ObterPorId(id);
            if (agendamento == null)
            {
                return NotFound(new { message = "Agendamento não encontrado." });
            }
            return Ok(agendamento);
        }

        // POST: api/agendamento/adicionar
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Clinica clinica)
        {
            var ClinicaRepository = _IClinicaRepository.CreateClinicaService();
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

           // clinica.id_clinica = ++_id;
            await ClinicaRepository.Adcionar(clinica);

            return Ok(new { message = "clinica cadastrado!", data = clinica });
        }

        // PUT: api/agendamento/atualizar/{id}
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Clinica clinica)
        {
            var ClinicaRepository = _IClinicaRepository.CreateClinicaService();
            if (id != clinica.id_clinica)
            {
                return BadRequest(new { message = "O ID informado não corresponde a clinica." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await ClinicaRepository.Atualizar(clinica);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar a clinica." });
            }

            return Ok(new { message = "clinica atualizada!", data = clinica });
        }

        // DELETE: api/agendamento/excluir/{id}
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var ClinicaRepository = _IClinicaRepository.CreateClinicaService();
            var clinica = await ClinicaRepository.ObterPorId(id);
            if (clinica == null)
            {
                return NotFound(new { message = "clinica não encontrado." });
            }

            await ClinicaRepository.Excluir(clinica);

            return Ok(new { message = "clinica excluída com sucesso!" });
        }
    }
}
