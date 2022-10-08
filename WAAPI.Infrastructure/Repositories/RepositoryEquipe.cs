using WAAPI.Application.Interfaces;
using WAAPI.Domain.Entities;
using WAAPI.Infrastructure.Context;

namespace WAAPI.Infrastructure.Repositories
{
    public class RepositoryEquipe : RepositoryBase<Equipe>, IRepositoryEquipe
    {
        private readonly ApplicationDbContext _context;

        public RepositoryEquipe(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<int> GetTotalEquipes()
        {
            return _context.Equipes.Count();
        }

    }
}
