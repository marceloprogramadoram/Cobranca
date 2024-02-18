using Cobranca.Service.DTO;

namespace Cobranca.Service.Interface
{
    public interface IBancoService
    {
        Task<int> CadastrarBanco(BancoDTO banco);
        Task<List<BancoDTO>> ListarBancos();
        Task<BancoDTO> LocalizarBanco(int codigoBanco);
    }
}
