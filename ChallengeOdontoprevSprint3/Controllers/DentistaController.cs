using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController : ControllerBase
    {
        //private readonly IDentistaRepository _IDentistaRepository;
        private readonly ISimpleFactory _IDentistaRepository;
        private static int _id = 0; // Controla o ID

        public DentistaController(ISimpleFactory ISimpleFactory)
        {
            _IDentistaRepository = ISimpleFactory;
        }

        // GET: api/agendamento
        [HttpGet]
        public async Task<ActionResult> Index()

        {
            var DentistaRepository = _IDentistaRepository.CreateDentistaService();
            
            return Ok(await DentistaRepository.Listar());
        }

        // GET: api/agendamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var DentistaRepository = _IDentistaRepository.CreateDentistaService();
            var dentista = await DentistaRepository.ObterPorId(id);
            if (dentista == null)
            {
                return NotFound(new { message = "Dentista não encontrado." });
            }
            return Ok(dentista);
        }

        // POST: api/agendamento/adicionar
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Dentista dentista)
        {
            var DentistaRepository = _IDentistaRepository.CreateDentistaService();
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

          //  dentista.id_dentista = ++_id;
            await DentistaRepository.Adcionar(dentista);

            return Ok(new { message = "Dentista cadastrado!", data = dentista });
        }

        // PUT: api/agendamento/atualizar/{id}
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Dentista dentista)
        {
            var DentistaRepository = _IDentistaRepository.CreateDentistaService();
            if (id != dentista.id_dentista)
            {
                return BadRequest(new { message = "O ID informado não corresponde ao Dentista." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await DentistaRepository.Atualizar(dentista);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar o Dentista." });
            }

            return Ok(new { message = "Dentista atualizado!", data = dentista });
        }

        // DELETE: api/agendamento/excluir/{id}
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var DentistaRepository = _IDentistaRepository.CreateDentistaService();
            var dentista = await DentistaRepository.ObterPorId(id);
            if (dentista == null)
            {
                return NotFound(new { message = "dentista não encontrado." });
            }

            await DentistaRepository.Excluir(dentista);

            return Ok(new { message = "dentista excluído com sucesso!" });
        }
    }
}

