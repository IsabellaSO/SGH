namespace SGH.Server.DTOs
{
    public class TipoQuartosDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Capacidade { get; set; }
        public int ValorDiaria { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }

    public class  CriarTipoQuartosDTO
    {
        public string Nome { get; set; } = string.Empty;
        public int Capacidade { get; set; }
        public int ValorDiaria { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
