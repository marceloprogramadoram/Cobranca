﻿using Cobranca.Service.DTO;
using Cobranca.Service.Interface;
using Cobranca.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cobranca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoService _boletoService;

        public BoletoController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        [HttpPost]
        public async Task<ActionResult> Save([FromBody] BoletoDTO boleto)
        {
            try
            {
                var result = _boletoService.SalvarBoleto(boleto);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
           
        }


        [HttpGet("{key}")]
        public async Task<ActionResult<List<BoletoDTO>>> GetByCodeBank(int key)
        {
            try
            {
                var result = await _boletoService.LocalizarBoleto(key);
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
