using WAAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAAPI.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
        string ReturnIdToken(String token);
    }
}
