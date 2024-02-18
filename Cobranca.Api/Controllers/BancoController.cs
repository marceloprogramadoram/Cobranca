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
            try
            {
                var result = await _bancoService.CadastrarBanco(banco);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<BancoDTO>>> GetAll()
        {
            try
            {
                var result = await _bancoService.ListarBancos();
                if (result.Count == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<List<BancoDTO>>> GetByCodeBank(int key)
        {
            try
            {
                var result = await _bancoService.LocalizarBanco(key);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }
}
