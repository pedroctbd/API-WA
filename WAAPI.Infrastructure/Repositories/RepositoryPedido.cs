using Microsoft.EntityFrameworkCore;
using WAAPI.Application.Interfaces;
using WAAPI.Application.Models.DAOs;
using WAAPI.Domain.Entities;
using WAAPI.Infrastructure.Context;

namespace WAAPI.Infrastructure.Repositories
{
    public class RepositoryPedido : RepositoryBase<Pedido>, IRepositoryPedido
    {
        private readonly ApplicationDbContext _context;

        public RepositoryPedido(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PedidoProdutoDao>> GetAllPedidos()
        {
            return await _context.Pedidos
                .Include(pedido => pedido.Equipe)
                .Include(pedido => pedido.PedidoProduto)
                .ThenInclude(pedidoproduto => pedidoproduto.Produto)
                .Select(s => new PedidoProdutoDao
                {
                    Pedido  = new Pedido {
                        DataCriacao =   s.DataCriacao,
                        DataEntrega =   s.DataEntrega,
                        Endereco = s.Endereco,
                        Equipe = s.Equipe,  
                    },
                    Produtos = s.PedidoProduto.Select(a => a.Produto)
                })
                .ToListAsync();
        }

        public async Task<List<PedidoProduto>> GetTop5Pedidos()
        {
            return await _context.Pedidos
                .Include(pedido => pedido.PedidoProduto)
                .ThenInclude(pedidoproduto => pedidoproduto.Produto)
                .Select(s =>new PedidoProduto{
                    IdPedido = s.Id,
                    Produto=new Produto {Valor = s.PedidoProduto
                      .Select(a => a.Produto)
                      .Sum(x => x.Valor)
                    } 
                }
    
                )
                .OrderByDescending(x=> x.Produto.Valor).Take(5).ToListAsync();
        }
    }
}