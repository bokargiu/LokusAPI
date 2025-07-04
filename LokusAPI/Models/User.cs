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

    }
}
