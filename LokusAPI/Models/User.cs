using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public User() { }
        public User(string username, string password, string email, string role)
        {
            Username = username;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
            Email = email;
            Role = role;
        }
    }
}
