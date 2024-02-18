using AutoMapper;
using Cobranca.Domain.Entities;
using Cobranca.Domain.Repository;
using Cobranca.Service.DTO;
using Cobranca.Service.Interface;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Service.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IBoletoRepository _boletoRepository;
        private readonly IBancoRepository _bancoRepository;
        private readonly IMapper _mapper;

        CultureInfo culture = new CultureInfo("en-US");
        public BoletoService(IBoletoRepository boletoRepository, IBancoRepository bancoRepository, IMapper mapper)
        {
            _boletoRepository = boletoRepository;
            _bancoRepository = bancoRepository;
            _mapper = mapper;
        }

        public async Task<BoletoDTO> LocalizarBoleto(int id)
        {
            var result = await _boletoRepository.LocalizarBoleto(id);

            var banco = await _bancoRepository.GetById(result.BancoId);

            if (result == null)
            {
                return null;
            }

            if (result.DataVencimento > DateTime.Now)
            {
                result.Valor += result.Valor * banco.PercJuros;
            }

            return _mapper.Map<BoletoDTO>(result);
        }

        public async Task SalvarBoleto(BoletoDTO boleto)
        {
            if (ValidaCampos(boleto))
            {
                var bol = _mapper.Map<Boleto>(boleto);
                await _boletoRepository.SalvarBoleto(bol);
            }
        }

        private bool ValidaCampos(BoletoDTO boleto)
        {
            if (string.IsNullOrEmpty(boleto.NomePagador)) throw new Exception("Nome do Pagador é obrigatório.");

            if ( string.IsNullOrEmpty(boleto.CpfCnpjPagador) ) return false;

            if (string.IsNullOrEmpty(boleto.NomeBeneficiario)) return false;

            if (string.IsNullOrEmpty(boleto.CpfCnpjBeneficiario)) return false;

            if ( boleto.Valor == 0 ) return false;

            if (boleto.DataVencimento == null) return false;

            if (boleto.BancoId == 0) return false;

            return true;
        }
    }
}
