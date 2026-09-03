using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGH.Server.Data;
using SGH.Server.DTOs;
using SGH.Server.Models;

namespace SGH.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReservaQuartoController: ControllerBase
    {
        private readonly HotelDbContext _context;

        public ReservaQuartoController(HotelDbContext context)
        {
            _context = context;
        }

        // URL no Swagger: GET /api/Quartos/GetAllReservaQuartos
        [HttpGet("GetAllReservaQuartos")]
        public async Task<ActionResult<IEnumerable<ReservaQuartosDTO>>> GetAllReservaQuartos()
        {
            var reservaQuartos = await _context.ReservaQuarto
                .Select(r => new ReservaQuartosDTO 
                {
                    Id = r.Id,
                    ReservaId = r.ReservaId,
                    QuartoId = r.QuartoId,
                    ValorDiaria = r.ValorDiaria
                })
                .ToListAsync();

            return Ok(reservaQuartos);
        }

        // URL no Swagger: GET /api/TipoQuartos/GetById/1
        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<ReservaQuartosDTO>> GetReservaQuartoById(int id)
        {
            var reservaQuarto = await _context.ReservaQuarto.FindAsync(id);

            if (reservaQuarto == null)
                return NotFound($"Reserva de quarto com ID {id} não foi encontrada.");

            var dto = new ReservaQuartosDTO
            {
                Id = reservaQuarto.Id,
                ReservaId = reservaQuarto.ReservaId,
                QuartoId = reservaQuarto.QuartoId,
                ValorDiaria = reservaQuarto.ValorDiaria
            };

            return Ok(dto);
        }

        // URL no Swagger: POST /api/Quartos/PostQuartos
        [HttpPost("PostReservaQuarto")]
        public async Task<ActionResult<ReservaQuartosDTO>> PostReservaQuarto(CriarReservaQuartosDTO dto)
        {
            var novaReservaQuarto = new ReservasQuartos
            {
                ReservaId = dto.ReservaId,
                QuartoId = dto.QuartoId,
                ValorDiaria = dto.ValorDiaria
            };

            _context.ReservaQuarto.Add(novaReservaQuarto);
            await _context.SaveChangesAsync();

            var response = new ReservaQuartosDTO
            {
                Id = novaReservaQuarto.Id,
                ReservaId = novaReservaQuarto.ReservaId,
                QuartoId = novaReservaQuarto.QuartoId,
                ValorDiaria = novaReservaQuarto.ValorDiaria
            };

            return CreatedAtAction(nameof(GetReservaQuartoById), new { id = response.Id }, response);
        }


        // PUT: api/ReservaQuartos/UpdateReservaQuartos/1
        [HttpPut("UpdateReservaQuartos/{id:int}")]
        public async Task<IActionResult> UpdateReservaQuartos(int id, CriarReservaQuartosDTO dto)
        {
            var reservaExistente = await _context.ReservaQuarto.FindAsync(id);

            if (reservaExistente == null)
                return NotFound($"Reserva de quarto com ID {id} não foi encontrada para atualização.");

            reservaExistente.ReservaId = dto.ReservaId;
            reservaExistente.QuartoId = dto.QuartoId;
            reservaExistente.ValorDiaria = dto.ValorDiaria;

            _context.ReservaQuarto.Update(reservaExistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ReservaQuartos/DeleteReservaQuartos/1
        [HttpDelete("DeleteReservaQuartos/{id:int}")]
        public async Task<IActionResult> DeleteReservaQuartos(int id)
        {
            var reserva = await _context.ReservaQuarto.FindAsync(id);

            if (reserva == null)
                return NotFound($"Reserva de quarto com ID {id} não foi encontrada para remoção.");

            _context.ReservaQuarto.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
