using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // <-- adicionar esta linha
using SGH.Server.Data;
using SGH.Server.DTOs;
using SGH.Server.Models;

namespace SGH.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController: ControllerBase
    {
        private readonly HotelDbContext _context;

        public ReservasController(HotelDbContext context)
        {
            _context = context;
        }

        // URL no Swagger: GET /api/Quartos/GetAlTipos
        [HttpGet("GetAllReservas")]
        public async Task<ActionResult<IEnumerable<ReservasDTO>>> GetAllReservas()
        {
            var reservas = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions
                .ToListAsync(_context.Reserva
                    .Select(r => new ReservasDTO
                    {
                        Id = r.Id,
                        HospedeId = r.HospedeId,
                        DataCheckin = r.DataCheckin,
                        DataCheckout = r.DataCheckout,
                        QuantidadePessoas = r.QuantidadePessoas,
                        StatusReserva = r.StatusReserva,
                        ValorTotal = r.ValorTotal
                    }));

            return Ok(reservas);
        }

        // URL no Swagger: GET /api/TipoQuartos/GetById/1
        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<ReservasDTO>> GetReservasById(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);

            if (reserva == null)
                return NotFound($"Reserva com ID {id} não foi encontrada.");

            var dto = new ReservasDTO
            {
                Id = reserva.Id,
                HospedeId = reserva.HospedeId,
                DataCheckin = reserva.DataCheckin,
                DataCheckout = reserva.DataCheckout,
                QuantidadePessoas = reserva.QuantidadePessoas,
                StatusReserva = reserva.StatusReserva,
                ValorTotal = reserva.ValorTotal
            };

            return Ok(dto);
        }

        // URL no Swagger: POST /api/Quartos/PostQuartos
        [HttpPost("PostReservas")]
        public async Task<ActionResult<ReservasDTO>> PostReservas(CriarReservasDTO dto)
        {
            var novaReserva = new Reservas
            {
                HospedeId = dto.HospedeId,
                DataCheckin = dto.DataCheckin,
                DataCheckout = dto.DataCheckout,
                QuantidadePessoas = dto.QuantidadePessoas,
                StatusReserva = dto.StatusReserva,
                ValorTotal = dto.ValorTotal
            };

            _context.Reserva.Add(novaReserva);
            await _context.SaveChangesAsync();

            var response = new ReservasDTO
            {
                Id = novaReserva.Id,
                HospedeId = novaReserva.HospedeId,
                DataCheckin = novaReserva.DataCheckin,
                DataCheckout = novaReserva.DataCheckout,
                QuantidadePessoas = novaReserva.QuantidadePessoas,
                StatusReserva = novaReserva.StatusReserva,
                ValorTotal = novaReserva.ValorTotal
            };

            return CreatedAtAction(nameof(GetReservasById), new { id = response.Id }, response);
        }


        // PUT: api/Reservas/UpdateReservas/1
        [HttpPut("UpdateReservas/{id:int}")]
        public async Task<IActionResult> UpdateReservas(int id, CriarReservasDTO dto)
        {
            var reservaExistente = await _context.Reserva.FindAsync(id);

            if (reservaExistente == null)
                return NotFound($"Reserva com ID {id} não foi encontrada para atualização.");

            reservaExistente.HospedeId = dto.HospedeId;
            reservaExistente.DataCheckin = dto.DataCheckin;
            reservaExistente.DataCheckout = dto.DataCheckout;
            reservaExistente.QuantidadePessoas = dto.QuantidadePessoas;
            reservaExistente.StatusReserva = dto.StatusReserva;
            reservaExistente.ValorTotal = dto.ValorTotal;

            _context.Reserva.Update(reservaExistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Reservas/DeleteReservas/1
        [HttpDelete("DeleteReservas/{id:int}")]
        public async Task<IActionResult> DeleteReservas(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);

            if (reserva == null)
                return NotFound($"Reserva com ID {id} não foi encontrada para remoção.");

            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
