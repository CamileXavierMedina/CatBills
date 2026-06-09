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
    public class DespesasController : ControllerBase
    {
        private readonly DataContext _context;

        public DespesasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarDespesaDto dto)
        {
            var utilizadorExiste = await _context.Utilizadores.AnyAsync(u => u.Id == dto.UtilizadorId);
            var categoriaExiste = await _context.Categorias.AnyAsync(c => c.Id == dto.CategoriaId);

            if (!utilizadorExiste || !categoriaExiste)
                return BadRequest("Utilizador ou Categoria informados não existem no sistema.");

            var despesa = new Despesa
            {
                Descricao = dto.Descricao,
                Valor = dto.Valor,
                DataVencimento = dto.DataVencimento,
                Pago = dto.Pago,
                MeioPagamento = dto.MeioPagamento.ToUpper(),
                TipoDespesa = dto.TipoDespesa.ToUpper(),
                UtilizadorId = dto.UtilizadorId,
                CategoriaId = dto.CategoriaId
            };

            _context.Despesas.Add(despesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = despesa.Id }, despesa);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodas()
        {
            var despesas = await _context.Despesas
                .Include(d => d.Utilizador)
                .Include(d => d.Categoria)
                .Select(d => new ExibirDespesaDto
                {
                    Id = d.Id,
                    Descricao = d.Descricao,
                    Valor = d.Valor,
                    DataVencimento = d.DataVencimento,
                    Pago = d.Pago,
                    MeioPagamento = d.MeioPagamento,
                    TipoDespesa = d.TipoDespesa,
                    NomeUtilizador = d.Utilizador != null ? d.Utilizador.Nome : "Desconhecido",
                    NomeCategoria = d.Categoria != null ? d.Categoria.Nome : "Sem Categoria"
                })
                .ToListAsync();

            return Ok(despesas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var despesa = await _context.Despesas
                .Include(d => d.Utilizador)
                .Include(d => d.Categoria)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (despesa == null) return NotFound("Despesa não encontrada.");

            var dto = new ExibirDespesaDto
            {
                Id = despesa.Id,
                Descricao = despesa.Descricao,
                Valor = despesa.Valor,
                DataVencimento = despesa.DataVencimento,
                Pago = despesa.Pago,
                MeioPagamento = despesa.MeioPagamento,
                TipoDespesa = despesa.TipoDespesa,
                NomeUtilizador = despesa.Utilizador?.Nome ?? "Desconhecido",
                NomeCategoria = despesa.Categoria?.Nome ?? "Sem Categoria"
            };

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] CriarDespesaDto dto)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null) return NotFound("Despesa não encontrada.");

            var utilizadorExiste = await _context.Utilizadores.AnyAsync(u => u.Id == dto.UtilizadorId);
            var categoriaExiste = await _context.Categorias.AnyAsync(c => c.Id == dto.CategoriaId);

            if (!utilizadorExiste || !categoriaExiste)
                return BadRequest("Utilizador ou Categoria informados são inválidos.");

            despesa.Descricao = dto.Descricao;
            despesa.Valor = dto.Valor;
            despesa.DataVencimento = dto.DataVencimento;
            despesa.Pago = dto.Pago;
            despesa.MeioPagamento = dto.MeioPagamento.ToUpper();
            despesa.TipoDespesa = dto.TipoDespesa.ToUpper();
            despesa.UtilizadorId = dto.UtilizadorId;
            despesa.CategoriaId = dto.CategoriaId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null) return NotFound("Despesa não encontrada.");

            _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}