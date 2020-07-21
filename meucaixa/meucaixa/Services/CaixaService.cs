using meucaixa.Interfaces;
using meucaixa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace meucaixa.Services
{
    class CaixaService : ICaixa
    {
        readonly ICaixaRepository _caixaRepository;
        readonly IPermissao _permissao;
        public CaixaService(ICaixaRepository caixaRepository, IPermissao permissao)
        {
            _caixaRepository = caixaRepository;
            _permissao = permissao;
        }

        public async Task AtualizaCaixa(Caixa caixa)
        {
            await _caixaRepository.AlteraCaixaAsync(caixa);
        }

        public async Task<List<Caixa>> ListaCaixas(int mes = 99)
        {
            return await _caixaRepository.ListaCaixasAsync(mes);
        }

        public async Task SalvaCaixa(Caixa caixa)
        {
            bool permissaoEscrita = await _permissao.VerificaESolicitaPermissao(new Permissions.StorageWrite());
            bool permissaoLeitura = await _permissao.VerificaESolicitaPermissao(new Permissions.StorageRead());
            if (permissaoEscrita && permissaoLeitura)
                await _caixaRepository.AdicionaCaixaAsync(caixa);
            else
                return;
        }
    }
}
