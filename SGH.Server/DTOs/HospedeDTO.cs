namespace SGH.Server.DTOs
{
    public class HospedeDTO
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

    public class CriarHospedeDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int CPF { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public int Idade { get; set; } //Igual data de nascimento

        //Pega a data e hora do momento do cadastro, não precisa ser enviado pelo usuário
        public int Cadastro { get; set; } = DateTime.Now.Year;
    }
}
