namespace SGH.Server.DTOs
{
    public class ReservasDTO
    {
        public int Id { get; set; }
        public int HospedeId { get; set; } = 0; //Id do hóspede que fez a reserva
        public DateTime DataCheckin { get; set; } //Data de check-in
        public DateTime DataCheckout { get; set; } //Data de check-out
        public int QuantidadePessoas { get; set; } //Quantidade de pessoas na reserva
        public string StatusReserva { get; set; } //Status da reserva (Pendente, Confirmada, Cancelada)
        public decimal ValorTotal { get; set; } //Valor total da reserva
    }

    public class CriarReservasDTO
    {
        public int HospedeId { get; set; } = 0; //Id do hóspede que fez a reserva
        public DateTime DataCheckin { get; set; } //Data de check-in
        public DateTime DataCheckout { get; set; } //Data de check-out
        public int QuantidadePessoas { get; set; } //Quantidade de pessoas na reserva
        public string StatusReserva { get; set; } //Status da reserva (Pendente, Confirmada, Cancelada)
        public decimal ValorTotal { get; set; } //Valor total da reserva
    }

    public class AtualizarReservasDTO
    {
        public int Id { get; set; }
        public int HospedeId { get; set; } = 0; //Id do hóspede que fez a reserva
        public DateTime DataCheckin { get; set; } //Data de check-in
        public DateTime DataCheckout { get; set; } //Data de check-out
        public int QuantidadePessoas { get; set; } //Quantidade de pessoas na reserva
        public string StatusReserva { get; set; } //Status da reserva (Pendente, Confirmada, Cancelada)
        public decimal ValorTotal { get; set; } //Valor total da reserva
    }
}
