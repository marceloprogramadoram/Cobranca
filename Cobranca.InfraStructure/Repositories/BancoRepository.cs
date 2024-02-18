using Cobranca.Domain.Entities;
using Cobranca.Domain.Repository;
using Cobranca.InfraStructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.InfraStructure.Repositories
{
    public class BancoRepository : Repository<Banco>, IBancoRepository
    {
        public BancoRepository(CobrancaContext context) : base(context)
        {
        }

        public async Task<List<Banco>> ListarBancos()
        {
            var listaDeBancos = await GetAll();
            return listaDeBancos.ToList();
        }

        public Task<Banco> LocalizarBanco(int codigoBanco)
        {
            var banco = Get(x => x.Codigo == codigoBanco);
            return banco;
        }

        public async Task<int> Salvar(Banco banco)
        {
            AddAsync(banco);
            return _context.SaveChanges();
        }
    }
}

