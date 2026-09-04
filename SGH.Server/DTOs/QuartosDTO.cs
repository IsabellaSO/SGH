using SGH.Server.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGH.Server.DTOs;

// DTO para retornar dados do Quarto
public class QuartosDTO
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public required string Andar { get; set; }
    public decimal PrecoDiaria { get; set; }
    public string Status { get; set; } = string.Empty;


    // 🔗 Chave Estrangeira para TiposQuarto
    public int TipoQuartoId { get; set; }

    // 🔗 Propriedade de Navegação do EF Core
    [ForeignKey("TipoQuartoId")]
    public TipoQuartos? TipoQuarto { get; set; }
}

// DTO usada especificamente na criação (sem ID e sem Status, pois são gerados automaticamente)
public class CriarQuartoDTO
{
    public string Numero { get; set; } = string.Empty;
    public required string Andar { get; set; }
    public decimal PrecoDiaria { get; set; }
    public int TipoQuartoId { get; set; } // <- Adicionado aqui!
}