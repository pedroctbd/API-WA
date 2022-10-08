using System.ComponentModel.DataAnnotations.Schema;

namespace WAAPI.Domain.Entities
{
    public class PedidoProduto
    {
        public int Id { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }

        [ForeignKey("Produto")]
        public int IdProduto { get; set; }

        public Pedido Pedido { get; set; }

        public Produto Produto { get; set; }    
    }
}
