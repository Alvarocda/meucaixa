using meucaixa.Interfaces;
using meucaixa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace meucaixa.Services
{
    class CaixaService : ICaixa
    {
        readonly ICaixaRepository _caixaRepository;
        public CaixaService(ICaixaRepository caixaRepository)
        {
            _caixaRepository = caixaRepository;
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
            await _caixaRepository.AdicionaCaixaAsync(caixa);
        }
    }
}
