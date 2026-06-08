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
    public class UtilizadoresController : ControllerBase
    {
        private readonly DataContext _context;

        public UtilizadoresController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarUtilizadorDto dto)
        {
            if (await _context.Utilizadores.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Este e-mail já está registado.");

            var utilizador = new Utilizador
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SalarioMensal = dto.SalarioMensal
            };

            _context.Utilizadores.Add(utilizador);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterPorId), new { id = utilizador.Id }, utilizador);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos() => Ok(await _context.Utilizadores.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var user = await _context.Utilizadores.FindAsync(id);
            return user == null ? NotFound() : Ok(user);
        }
    }
}