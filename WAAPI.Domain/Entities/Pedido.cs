using System.Text.Json.Serialization;

namespace WAAPI.Domain.Entities
{
    public class Pedido
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTimeOffset DataEntrega { get; set; }
        public DateTimeOffset DataCriacao { get; set; }
        public string? Endereco { get; set; }
        public Equipe Equipe { get; set; }

        [JsonIgnore]
        public List<PedidoProduto> PedidoProduto { get; set; }

        public Pedido()
        {

        }
        public Pedido(DateTimeOffset dataEntrega, string? endereco, Equipe equipe)
        {
            DataEntrega = dataEntrega;
            DataCriacao = DateTimeOffset.Now;
            Endereco = endereco;
            Equipe = equipe;
            PedidoProduto = new List<PedidoProduto>();
        }
    }
}
