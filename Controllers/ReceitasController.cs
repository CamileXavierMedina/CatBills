using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatBills.Data;
using CatBills.Models;
using CatBills.DTOs;

namespace CatBills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceitasController : ControllerBase
    {
        private readonly DataContext _context;

        public ReceitasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarReceitaDto dto)
        {
            var receita = new Receita
            {
                Descricao = dto.Descricao,
                Valor = dto.Valor,
                Data = dto.Data,
                Origem = dto.Origem
            };

            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = receita.Id }, receita);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodas()
        {
            var receitas = await _context.Receitas
                .Select(r => new ExibirReceitaDto
                {
                    Id = r.Id,
                    Descricao = r.Descricao,
                    Valor = r.Valor,
                    Data = r.Data,
                    Origem = r.Origem
                })
                .ToListAsync();

            return Ok(receitas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null) return NotFound("Receita não encontrada.");

            var dto = new ExibirReceitaDto
            {
                Id = receita.Id,
                Descricao = receita.Descricao,
                Valor = receita.Valor,
                Data = receita.Data,
                Origem = receita.Origem
            };

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] CriarReceitaDto dto)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null) return NotFound("Receita não encontrada.");

            receita.Descricao = dto.Descricao;
            receita.Valor = dto.Valor;
            receita.Data = dto.Data;
            receita.Origem = dto.Origem;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null) return NotFound("Receita não encontrada.");

            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
