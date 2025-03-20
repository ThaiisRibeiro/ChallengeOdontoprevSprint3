using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaPrecoController : ControllerBase
    {
            private readonly ISimpleFactory _ITabelaPrecoRepository;
            private static int _id = 0; // Controla o ID

            public TabelaPrecoController(ISimpleFactory ITabelaPrecoRepository)
            {
            _ITabelaPrecoRepository = ITabelaPrecoRepository;
            }

            // GET: api/agendamento
            [HttpGet]
            public async Task<ActionResult> Index()
            {
            var TabelaPrecoRepository = _ITabelaPrecoRepository.CreateTabelaPrecoService();
            return Ok(await TabelaPrecoRepository.Listar());
            }

            // GET: api/agendamento/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult> ObterPorId(int id)
            {
            var TabelaPrecoRepository = _ITabelaPrecoRepository.CreateTabelaPrecoService();
            var tabelapreco = await TabelaPrecoRepository.ObterPorId(id);
                if (tabelapreco == null)
                {
                    return NotFound(new { message = "Tabela Preco não encontrada." });
                }
                return Ok(tabelapreco);
            }

            // POST: api/agendamento/adicionar
            [HttpPost("adicionar")]
            public async Task<ActionResult> Adicionar([FromBody] TabelaPreco tabelapreco)
            {
            var TabelaPrecoRepository = _ITabelaPrecoRepository.CreateTabelaPrecoService();
            if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Dados inválidos." });
                }

           // tabelapreco.id_tabela_preco = ++_id;
                await TabelaPrecoRepository.Adcionar(tabelapreco);

                return Ok(new { message = "Tabela Preco cadastrada!", data = tabelapreco });
            }

            // PUT: api/agendamento/atualizar/{id}
            [HttpPut("atualizar/{id}")]
            public async Task<ActionResult> Atualizar(int id, [FromBody] TabelaPreco tabelapreco)
            {
            var TabelaPrecoRepository = _ITabelaPrecoRepository.CreateTabelaPrecoService();
            if (id != tabelapreco.id_tabela_preco)
                {
                    return BadRequest(new { message = "O ID informado não corresponde o Paciente." });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Dados inválidos." });
                }

                try
                {
                    await TabelaPrecoRepository.Atualizar(tabelapreco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Conflict(new { message = "Erro de concorrência ao atualizar a Tabela Preco." });
                }

                return Ok(new { message = "tabela preco atualizada!", data = tabelapreco });
            }

            // DELETE: api/agendamento/excluir/{id}
            [HttpDelete("excluir/{id}")]
            public async Task<ActionResult> Excluir(int id)
        {
            var TabelaPrecoRepository = _ITabelaPrecoRepository.CreateTabelaPrecoService();
            var tabelapreco = await TabelaPrecoRepository.ObterPorId(id);
                if (tabelapreco == null)
                {
                    return NotFound(new { message = "tabela preco não encontrada." });
                }

                await TabelaPrecoRepository.Excluir(tabelapreco);

                return Ok(new { message = "tabela preco excluída com sucesso!" });
            }
        }
    }

