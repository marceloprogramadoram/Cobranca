using Cobranca.Service.DTO;
using Cobranca.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cobranca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpPost]
        public async Task<ActionResult> Save([FromBody]BancoDTO banco)
        {
            var result = await _bancoService.CadastrarBanco(banco);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<BancoDTO>>> GetAll()
        {
            var result = await _bancoService.ListarBancos();
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<List<BancoDTO>>> GetByCodeBank(int key)
        {
            var result = await _bancoService.LocalizarBanco(key);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
