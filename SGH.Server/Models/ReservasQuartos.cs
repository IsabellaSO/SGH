namespace SGH.Server.Models
{
    public class ReservasQuartos
    {
        public int Id { get; set; }
        public int ReservaId { get; set; } //Id da reserva
        public int QuartoId { get; set; } //Id do quarto reservado
        public decimal ValorDiaria { get; set; } //Valor da diária do quarto aplicado na reserva
    }
}
