using Cobranca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Domain.Repository
{
    public interface IBoletoRepository : IRepository<Boleto>
    {
        Task SalvarBoleto(Boleto boleto);
        Task<Boleto> LocalizarBoleto(int id);
    }
}
