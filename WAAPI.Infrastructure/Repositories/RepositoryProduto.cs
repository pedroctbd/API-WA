using WAAPI.Application.Interfaces;
using WAAPI.Domain.Entities;
using WAAPI.Infrastructure.Context;

namespace WAAPI.Infrastructure.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly ApplicationDbContext _context;

        public RepositoryProduto(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<float> GetTotalMoneySpent()
        {
            return _context.Produtos.Sum(p => p.Valor);
        }

    }
}
