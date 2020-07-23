using meucaixa.Interfaces;
using meucaixa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace meucaixa.Services
{
    public class DespesaService : IDespesa
    {
        readonly IDespesaRepository<Despesa> _despesasRepository;
        public DespesaService(IDespesaRepository<Despesa> despesasRepository)
        {
            _despesasRepository = despesasRepository;
        }
        public async Task SalvaDespesasAsync(Caixa caixa)
        {
            foreach (Despesa despesa in caixa.Despesas)
            {
                despesa.CaixaId = caixa.Id;
            }
            await _despesasRepository.AdicionaDespesas(caixa.Despesas);
        }

        public async Task AlteraDespesaAsync(Despesa despesa)
        {
            await _despesasRepository.AlteraRegistro(despesa);
        }

        public async Task<List<Despesa>> ListaTodasDespesasAsync(int caixaId = 0)
        {
            if (caixaId != 0)
            {
                return await _despesasRepository.Lista(d => d.CaixaId == caixaId);
            }
            return await _despesasRepository.Lista();
        }

        public async Task<Despesa> SelecionaDespesaAsync(int codDespesa)
        {
            return await _despesasRepository.SelecionaPorId(codDespesa);
        }
    }
}
