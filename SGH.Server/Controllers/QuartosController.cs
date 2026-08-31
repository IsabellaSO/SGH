using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGH.Server.Data;
using SGH.Server.DTOs;
using SGH.Server.Models;

namespace SGH.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuartosController : ControllerBase
{
    private readonly HotelDbContext _context;

    public QuartosController(HotelDbContext context)
    {
        _context = context;
    }

    // URL no Swagger: GET /api/Quartos/GetAllQuartos
    [HttpGet("GetAllQuartos")]
    public async Task<ActionResult<IEnumerable<QuartosDTO>>> GetAllQuartos()
    {
        var quartos = await _context.Quartos
            .Select(q => new QuartosDTO
            {
                Id = q.Id,
                Numero = q.Numero,
                Andar = q.Andar,
                PrecoDiaria = q.PrecoDiaria,
                Status = q.Status
            })
            .ToListAsync();

        return Ok(quartos);
    }

    // URL no Swagger: GET /api/Quartos/GetById/1
    [HttpGet("GetById/{id:int}")]
    public async Task<ActionResult<QuartosDTO>> GetQuartosById(int id)
    {
        var quarto = await _context.Quartos.FindAsync(id);

        if (quarto == null)
            return NotFound($"Quarto com ID {id} não foi encontrado.");

        var dto = new QuartosDTO
        {
            Id = quarto.Id,
            Numero = quarto.Numero,
            Andar = quarto.Andar,
            PrecoDiaria = quarto.PrecoDiaria,
            Status = quarto.Status
        };

        return Ok(dto);
    }

    // URL no Swagger: POST /api/Quartos/PostQuartos
    [HttpPost("PostQuartos")]
    public async Task<ActionResult<QuartosDTO>> PostQuartos(CriarQuartoDTO dto)
    {
        var novoQuarto = new Quartos
        {
            Numero = dto.Numero,
            Andar = dto.Andar,
            PrecoDiaria = dto.PrecoDiaria,
            Status = "DISPONIVEL"
        };

        _context.Quartos.Add(novoQuarto);
        await _context.SaveChangesAsync();

        var response = new QuartosDTO
        {
            Id = novoQuarto.Id,
            Numero = novoQuarto.Numero,
            Andar = novoQuarto.Andar,
            PrecoDiaria = novoQuarto.PrecoDiaria,
            Status = novoQuarto.Status
        };

        return CreatedAtAction(nameof(GetQuartosById), new { id = response.Id }, response);
    }

    // PUT: api/Quartos/UpdateQuartos/1
    [HttpPut("UpdateQuartos/{id:int}")]
    public async Task<IActionResult> UpdateQuartos(int id, CriarQuartoDTO dto)
    {
        var quartoExistente = await _context.Quartos.FindAsync(id);

        if (quartoExistente == null)
            return NotFound($"Quarto com ID {id} não foi encontrado para atualização.");

        // Atualiza as propriedades com base nos novos dados
        quartoExistente.Numero = dto.Numero;
        quartoExistente.Andar = dto.Andar;
        quartoExistente.PrecoDiaria = dto.PrecoDiaria;

        _context.Quartos.Update(quartoExistente);
        await _context.SaveChangesAsync();

        return NoContent(); // HTTP 204: Atualizado com sucesso e sem retorno de corpo
    }

    // DELETE: api/Quartos/DeleteQuartos/1
    [HttpDelete("DeleteQuartos/{id:int}")]
    public async Task<IActionResult> DeleteQuartos(int id)
    {
        var quarto = await _context.Quartos.FindAsync(id);

        if (quarto == null)
            return NotFound($"Quarto com ID {id} não foi encontrado para remoção.");

        _context.Quartos.Remove(quarto);
        await _context.SaveChangesAsync();

        return NoContent(); // HTTP 204: Removido com sucesso
    }
}