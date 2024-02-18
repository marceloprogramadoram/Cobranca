using Cobranca.Domain.Entities;
using Cobranca.Domain.Repository;
using Cobranca.InfraStructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.InfraStructure.Repositories
{
    public class BoletoRepository : Repository<Boleto>, IBoletoRepository
    {
        public BoletoRepository(CobrancaContext context) : base(context)
        {
        }

        public async Task<Boleto> LocalizarBoleto(int id)
        {
            var boleto = await GetById(id);

            return boleto;

        }

        public async Task SalvarBoleto(Boleto boleto)
        {
            await AddAsync(boleto);
            
            _context.SaveChanges();

        }
    }
}
