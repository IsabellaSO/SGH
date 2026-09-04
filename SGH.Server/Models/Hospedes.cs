namespace SGH.Server.Models
{
    public class Hospedes
    {
        //chave primária
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public int CPF { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public int Idade { get; set; } //Igual data de nascimento

        //Pega a data e hora do momento do cadastro, não precisa ser enviado pelo usuário
        public int Cadastro { get; set; } = DateTime.Now.Year;
    }
}
