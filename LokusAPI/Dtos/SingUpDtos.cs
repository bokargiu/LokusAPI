namespace LokusAPI.Dtos
{
    public class SingUpClientDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
    }
    public class SingUpCompanyDto
    {

    }
}
