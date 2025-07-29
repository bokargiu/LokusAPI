namespace LokusAPI.Dtos
{
    public class CompanyDto
    {
        public string NameCompany { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string ContactOther { get; set; } = string.Empty;


        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Company";

        public CompanyDto() { }
        public CompanyDto(string nameCompany, string cnpj, string contactOther, string username, string password, string email, string role)
        {
            NameCompany = nameCompany;
            Cnpj = cnpj;
            ContactOther = contactOther;
            Username = username;
            Password = password;
            Email = email;
            Role = role;
        }
    }
}
