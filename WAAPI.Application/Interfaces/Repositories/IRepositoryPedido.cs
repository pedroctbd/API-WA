

using WAAPI.Application.Models.DAOs;
using WAAPI.Domain.Entities;

namespace WAAPI.Application.Interfaces
{
    public interface IRepositoryPedido : IRepositoryBase<Pedido>
    {
        Task<List<PedidoProdutoDao>> GetAllPedidos();
        Task<List<PedidoProduto>> GetTop5Pedidos();

    }
}