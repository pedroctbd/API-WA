
using WAAPI.Domain.Entities;

namespace WAAPI.Application.Models.DAOs
{
    public class PedidoProdutoDao
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}