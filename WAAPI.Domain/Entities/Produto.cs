using System.Text.Json.Serialization;

namespace WAAPI.Domain.Entities
{
    public class Produto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public float Valor { get; set; }
        public string? Descricao { get; set; }
        [JsonIgnore]
        public List<PedidoProduto> PedidoProduto { get; set; }

        public Produto()
        {

        }
        public Produto(string nome, float valor, string descricao)
        {
            Nome = nome;
            Valor = valor;
            Descricao = descricao;
        }
    }
  
}
 