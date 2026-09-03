using SGH.Server.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGH.Server.DTOs
{
    public class ReservaQuartosDTO
    {
        public int Id { get; set; }

        // 🔗 Chave Estrangeira para Reservas
        public int ReservaId { get; set; } //Id da reserva

        //Chave Estrangeira para Quartos
        public int QuartoId { get; set; } //Id do quarto reservado
        public decimal ValorDiaria { get; set; } //Valor da diária do quarto aplicado na reserva

        
        // 🔗 Propriedade de Navegação do EF Core
        [ForeignKey("ReservaId")]
        public Reservas? Reserva { get; set; }

        [ForeignKey("QuartoId")]
        public Quartos? Quarto { get; set; } = null;
    }

    public class CriarReservaQuartosDTO
    {
        public int ReservaId { get; set; } //Id da reserva
        public int QuartoId { get; set; } //Id do quarto reservado
        public decimal ValorDiaria { get; set; } //Valor da diária do quarto aplicado na reserva
    }
}
