namespace SGH.Server.DTOs;

// DTO para retornar dados do Quarto
public class QuartosDTO
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public required string Andar { get; set; }
    public decimal PrecoDiaria { get; set; }
    public string Status { get; set; } = string.Empty;
}

// DTO usada especificamente na criação (sem ID e sem Status, pois são gerados automaticamente)
public class CriarQuartoDTO
{
    public string Numero { get; set; } = string.Empty;
    public required string Andar { get; set; }
    public decimal PrecoDiaria { get; set; }
}