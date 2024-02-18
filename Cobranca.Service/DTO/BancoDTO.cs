using Cobranca.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cobranca.Service.DTO
{
    public class BancoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public float PercJuros { get; set; }
        [JsonIgnore]
        public List<BoletoDTO>? ListBoleto { get; set; }
    }
}
