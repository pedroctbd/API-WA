using WAAPI.Domain.Entities;

namespace WAAPI.Application.Models.DAOs
{
    public class JwtDao : User
    {
        public String? Token { get; set; }
    }
}
