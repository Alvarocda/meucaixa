using meucaixa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace meucaixa.Interfaces
{
    public interface ICaixaRepository
    {
        Task AdicionaCaixaAsync(Caixa caixa);
        Task AlteraCaixaAsync(Caixa caixa);
        Task<List<Caixa>> ListaCaixasAsync(int mes = 99);
        Task<Caixa> SelecionaCaixaAsync(int id);
    }
}
