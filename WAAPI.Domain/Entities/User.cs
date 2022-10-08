using System.Text.Json.Serialization;

namespace WAAPI.Domain.Entities
{
    public class User
    {
        [JsonIgnore]
        public int Id{ get; set; }
        public string? UserName { get; set; }

        [JsonIgnore]
        public byte[]? PasswordSalt { get; set; }

        [JsonIgnore]
        public byte[]? PasswordHash { get; set; }
        public string? Email { get; set; }
    }
}