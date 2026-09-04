namespace SGH.Server.Models
{
    public class TipoQuartos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Capacidade { get; set; }
        public int ValorDiaria { get; set; }
        public string Descricao { get; set; } = string.Empty;

        public ICollection<Quartos> Quartos { get; set; } = new List<Quartos>();
    }
}
