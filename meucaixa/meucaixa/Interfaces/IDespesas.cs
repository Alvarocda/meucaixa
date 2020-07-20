using meucaixa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace meucaixa.Interfaces
{
    public interface IDespesas
    {
        Task SalvaDespesasAsync(Caixa caixa);
        Task AlteraDespesaAsync(Despesa despesa);
        Task<List<Despesa>> ListaTodasDespesasAsync(int CaixaId = 0);
        Task<Despesa> SelecionaDespesaAsync(int codDespesa);
    }
}
