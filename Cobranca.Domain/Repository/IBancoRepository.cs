using Cobranca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Domain.Repository
{
    public interface IBancoRepository : IRepository<Banco>
    {
        Task<int> Salvar(Banco banco);
        Task<Banco> LocalizarBanco(int codigoBanco);
        Task<List<Banco>> ListarBancos();
    }
}
