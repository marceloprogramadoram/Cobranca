using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cobranca.Service.DTO
{
    public class BoletoDTO
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
        [JsonIgnore]
        public BancoDTO? Banco { get; set; }

    }
}
