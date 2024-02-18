using System.Text.Json.Serialization;

namespace Cobranca.Domain.Entities
{
    public class Banco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public float PercJuros { get; set; }
        public List<Boleto>? ListBoleto { get; set; }
    }
}
