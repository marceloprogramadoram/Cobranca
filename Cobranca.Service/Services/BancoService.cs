using AutoMapper;
using Cobranca.Domain.Entities;
using Cobranca.Domain.Repository;
using Cobranca.Service.DTO;
using Cobranca.Service.Interface;

namespace Cobranca.Service.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IMapper _mapper;
        public BancoService(IBancoRepository bancoRepository, IMapper mapper)
        {
            _bancoRepository = bancoRepository;
            _mapper = mapper;
        }

        public async Task<int> CadastrarBanco(BancoDTO banco)
        {
            if (ValidaCampos(banco))
            {
                var _banco = _mapper.Map<Banco>(banco);

                return await _bancoRepository.Salvar(_banco);
            }
            return 0;
        }

        public async Task<List<BancoDTO>> ListarBancos()
        {
            var lista = await _bancoRepository.GetAll();

            var result = new List<BancoDTO>();

            lista.ToList().ForEach(x =>
            {
                var item = _mapper.Map<BancoDTO>(x);
                result.Add(item);
            });

            return result;
        }

        public async Task<BancoDTO> LocalizarBanco(int codigoBanco)
        {
            var banco = await _bancoRepository.LocalizarBanco(codigoBanco);

            return _mapper.Map<BancoDTO>(banco);
        }

        private bool ValidaCampos(BancoDTO banco)
        {
            if (string.IsNullOrEmpty(banco.Nome)) return false;

            if (banco.Codigo == 0) return false;

            if (banco.PercJuros == 0) return false;

            return true;
        }
    }
}
