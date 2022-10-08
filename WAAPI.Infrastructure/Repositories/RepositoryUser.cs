using Microsoft.EntityFrameworkCore;
using WAAPI.Application.Interfaces;
using WAAPI.Domain.Entities;
using WAAPI.Infrastructure.Context;

namespace WAAPI.Infrastructure.Repositories
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly ApplicationDbContext _context;

        public RepositoryUser(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string Email)
        {
         
            return await _context.Users.FirstOrDefaultAsync(stored_users => stored_users.Email == Email);

        }
    }
}
