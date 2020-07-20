using meucaixa.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace meucaixa.Interfaces
{
    public interface IDespesasRepository
    {
        Task AdicionaDespesaAsync(ObservableCollection<Despesa> despesas);
        Task AlteraDespesaAsync(Despesa caixa);
        Task<List<Despesa>> ListaDespesas(int caixaId = 0);
        Task<Despesa> SelecionaDespesa(int id);
    }
}
