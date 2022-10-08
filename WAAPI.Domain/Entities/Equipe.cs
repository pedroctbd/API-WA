using System.Text.Json.Serialization;

namespace WAAPI.Domain.Entities
{
    public class Equipe
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? PlacaVeiculo { get; set; }
        public Equipe(string nome, string descricao, string placaVeiculo)
        {
            Nome = nome;
            Descricao = descricao;
            PlacaVeiculo = placaVeiculo;
        }

    }
}
 