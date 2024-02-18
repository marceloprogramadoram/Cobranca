using Cobranca.Domain.Entities;
using Cobranca.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Service.Interface
{
    public interface IBoletoService
    {
        Task SalvarBoleto(BoletoDTO boleto);
        Task<BoletoDTO> LocalizarBoleto(int id);
    }
}
