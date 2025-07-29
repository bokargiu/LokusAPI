namespace LokusAPI.Dtos
{
    public class CustomerDto
    {
        public string nomeCompleto { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime dataNascimento { get; set; } = DateTime.MinValue; 
        public string Contato { get; set; } = string.Empty; 
        

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Cliente";

        public CustomerDto() { }

        public CustomerDto(string nomeCompleto, string cPF, DateTime dataNascimento, string email, string contato, string username, string password, string role)
        {
            this.nomeCompleto = nomeCompleto;
            CPF = cPF;
            this.dataNascimento = dataNascimento;
            Email = email;
            Contato = contato;
            Username = username;
            Password = password;
            Role = role;
        }
    }


}
