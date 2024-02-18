using System.Text.Json.Serialization;

namespace Cobranca.Domain.Entities
{
    public class Boleto
    {
        public int Id { get; set; }
        public string NomePagador { get; set; }
        public string CpfCnpjPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string CpfCnpjBeneficiario { get; set; }
        public float Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacao { get; set; }
        public int BancoId { get; set; }
        public Banco? Banco { get; set; }
    }
}
