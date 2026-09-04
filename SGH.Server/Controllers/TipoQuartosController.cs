using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGH.Server.Data;
using SGH.Server.DTOs;
using SGH.Server.Models;

namespace SGH.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TipoQuartosController: ControllerBase
    {
        private readonly HotelDbContext _context;

        public TipoQuartosController(HotelDbContext context)
        {
            _context = context;
        }

        // URL no Swagger: GET /api/Quartos/GetAlTipos
        [HttpGet("GetAllTipos")]
        public async Task<ActionResult<IEnumerable<TipoQuartosDTO>>> GetAllTipos()
        {
            var tipos = await _context.TipoQuarto
                .Select(t => new TipoQuartosDTO
                {
                    Id = t.Id,
                    Nome = t.Nome, 
                    Capacidade = t.Capacidade,
                    ValorDiaria = t.ValorDiaria,
                    Descricao = t.Descricao
                })
                .ToListAsync();

            return Ok(tipos);
        }

        // URL no Swagger: GET /api/TipoQuartos/GetById/1
        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<TipoQuartosDTO>> GetTipoQuartosById(int id)
        {
            var tipoQuarto = await _context.TipoQuarto.FindAsync(id);

            if (tipoQuarto == null)
                return NotFound($"Tipo de quarto com ID {id} não foi encontrado.");

            var dto = new TipoQuartosDTO
            {
                Id = tipoQuarto.Id,
                Nome = tipoQuarto.Nome,
                Capacidade = tipoQuarto.Capacidade,
                ValorDiaria = tipoQuarto.ValorDiaria,
                Descricao = tipoQuarto.Descricao
            };

            return Ok(dto);
        }

        // URL no Swagger: POST /api/Quartos/PostQuartos
        [HttpPost("PostTipoQuartos")]
        public async Task<ActionResult<TipoQuartosDTO>> PostTipoQuartos(CriarTipoQuartosDTO dto)
        {

            var novoTipoQuarto = new TipoQuartos
            {
                Nome = dto.Nome,
                Capacidade = dto.Capacidade,
                ValorDiaria = dto.ValorDiaria,
                Descricao = dto.Descricao
            };

            _context.TipoQuarto.Add(novoTipoQuarto);
            await _context.SaveChangesAsync();

            var response = new TipoQuartosDTO
            {
                Id = novoTipoQuarto.Id,
                Nome = novoTipoQuarto.Nome,
                Capacidade = novoTipoQuarto.Capacidade,
                ValorDiaria = novoTipoQuarto.ValorDiaria,
                Descricao = novoTipoQuarto.Descricao
            };

            return CreatedAtAction(nameof(GetTipoQuartosById), new { id = response.Id }, response);
        }


        // PUT: api/TipoQuartos/UpdateTipoQuartos/1
        [HttpPut("UpdateTipoQuartos/{id:int}")]
        public async Task<IActionResult> UpdateTipoQuartos(int id, CriarTipoQuartosDTO dto)
        {
            var tipoExistente = await _context.TipoQuarto.FindAsync(id);

            if (tipoExistente == null)
                return NotFound($"Tipo de quarto com ID {id} não foi encontrado para atualização.");

            tipoExistente.Nome = dto.Nome;
            tipoExistente.Capacidade = dto.Capacidade;
            tipoExistente.ValorDiaria = dto.ValorDiaria;
            tipoExistente.Descricao = dto.Descricao;

            _context.TipoQuarto.Update(tipoExistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/TipoQuartos/DeleteTipoQuartos/1
        [HttpDelete("DeleteTipoQuartos/{id:int}")]
        public async Task<IActionResult> DeleteTipoQuartos(int id)
        {
            var tipo = await _context.TipoQuarto.FindAsync(id);

            if (tipo == null)
                return NotFound($"Tipo de quarto com ID {id} não foi encontrado para remoção.");

            _context.TipoQuarto.Remove(tipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }


}
