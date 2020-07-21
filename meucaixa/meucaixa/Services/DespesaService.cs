using meucaixa.Interfaces;
using meucaixa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace meucaixa.Services
{
    public class DespesaService : IDespesas
    {
        readonly IDespesasRepository _despesasRepository;
        public DespesaService(IDespesasRepository despesasRepository)
        {
            _despesasRepository = despesasRepository;
        }
        public async Task SalvaDespesasAsync(Caixa caixa)
        {
            foreach (Despesa despesa in caixa.Despesas)
            {
                despesa.CaixaId = caixa.Id;
            }
            await _despesasRepository.AdicionaDespesaAsync(caixa.Despesas);
        }

        public async Task AlteraDespesaAsync(Despesa despesa)
        {
            await _despesasRepository.AlteraDespesaAsync(despesa);
        }

        public async Task<List<Despesa>> ListaTodasDespesasAsync(int CaixaId = 0)
        {
            return await _despesasRepository.ListaDespesas(CaixaId);
        }

        public async Task<Despesa> SelecionaDespesaAsync(int codDespesa)
        {
            return await _despesasRepository.SelecionaDespesa(codDespesa);
        }
    }
}
