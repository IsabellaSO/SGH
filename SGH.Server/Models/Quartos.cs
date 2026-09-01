using System.ComponentModel.DataAnnotations.Schema;

namespace SGH.Server.Models
{
    public class Quartos
    {
        //chave primária
        public int Id { get; set; }

        public string Numero { get; set; } = string.Empty;
        public string Andar { get; set; }
        public decimal PrecoDiaria { get; set; }

        //padrão inicial ao cadastrar um novo quarto, o status será DISPONÍVEL
        public string Status { get; set; } = "DISPONÍVEL";

        // 🔗 Chave Estrangeira para TiposQuarto
        public int TipoQuartoId { get; set; }

        // 🔗 Propriedade de Navegação do EF Core
        [ForeignKey("TipoQuartoId")]
        public TipoQuartos? TipoQuarto { get; set; }
    }
}
