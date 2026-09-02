using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGH.Server.Data;
using SGH.Server.DTOs;
using SGH.Server.Models;

namespace SGH.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospedesController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public HospedesController(HotelDbContext context)
        {
            _context = context;
        }

        // URL no Swagger: GET /api/Quartos/GetAllQuartos
        [HttpGet("GetAllQuartos")]
        public async Task<ActionResult<IEnumerable<HospedeDTO>>> GetAllHospedes()
        {
            var hospedes = await _context.Hospede
                .Select(h => new HospedeDTO
                {
                    Id = h.Id,
                    Name = h.Name,
                    Email = h.Email,
                    CPF = h.CPF,
                    Telefone = h.Telefone,
                    Idade = h.Idade,
                    Cadastro = h.Cadastro
                })
                .ToListAsync();

            return Ok(hospedes);
        }


        // URL no Swagger: GET /api/Quartos/GetById/1
        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<HospedeDTO>> GetHospedeById(int id)
        {
            var hospede = await _context.Hospede.FindAsync(id);

            if (hospede == null)
                return NotFound($"Hospede com ID {id} não foi encontrado.");

            var dto = new HospedeDTO
            {
                Id = hospede.Id,
                Name = hospede.Name,
                Email = hospede.Email,
                CPF = hospede.CPF,
                Telefone = hospede.Telefone,
                Idade = hospede.Idade,
                Cadastro = hospede.Cadastro
            };

            return Ok(dto);
        }

        // URL no Swagger: POST /api/Quartos/PostQuartos
        [HttpPost("PostHospedes")]
        public async Task<ActionResult<HospedeDTO>> PostHospedes(CriarHospedeDTO dto)
        {
            var novoHospede = new Hospedes
            {
                Name = dto.Name,
                Email = dto.Email,
                CPF = dto.CPF,
                Telefone = dto.Telefone,
                Idade = dto.Idade,
                Cadastro = dto.Cadastro
            };

            _context.Hospede.Add(novoHospede);
            await _context.SaveChangesAsync();

            var response = new HospedeDTO
            {
                Id = novoHospede.Id,
                Name = novoHospede.Name,
                Email = novoHospede.Email,
                CPF = novoHospede.CPF,
                Telefone = novoHospede.Telefone,
                Idade = novoHospede.Idade,
                Cadastro = novoHospede.Cadastro
            };

            return CreatedAtAction(nameof(GetHospedeById), new { id = response.Id }, response);
        }

        // PUT: api/Quartos/UpdateQuartos/1
        [HttpPut("UpdateHospedes/{id:int}")]
        public async Task<IActionResult> UpdateHospedes(int id, CriarHospedeDTO dto)
        {
            var hospedeExistente = await _context.Hospede.FindAsync(id);

            if (hospedeExistente == null)
                return NotFound($"Hospede com ID {id} não foi encontrado para atualização.");

            // Atualiza as propriedades do hóspede
            hospedeExistente.Name = dto.Name;
            hospedeExistente.Email = dto.Email;
            hospedeExistente.CPF = dto.CPF;
            hospedeExistente.Telefone = dto.Telefone;
            hospedeExistente.Idade = dto.Idade;
            hospedeExistente.Cadastro = dto.Cadastro;

            _context.Hospede.Update(hospedeExistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Quartos/DeleteQuartos/1
        [HttpDelete("DeleteHospedes/{id:int}")]
        public async Task<IActionResult> DeleteHospedes(int id)
        {
            var hospede = await _context.Hospede.FindAsync(id);

            if (hospede == null)
                return NotFound($"Hospede com ID {id} não foi encontrado para remoção.");

            _context.Hospede.Remove(hospede);
            await _context.SaveChangesAsync();

            return NoContent(); // HTTP 204: Removido com sucesso
        }
    }
}
