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
    }
}
