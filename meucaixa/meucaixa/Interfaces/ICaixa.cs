using meucaixa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace meucaixa.Interfaces
{
    public interface ICaixa
    {
        Task SalvaCaixa(Caixa caixa);
        Task AtualizaCaixa(Caixa caixa);
        Task<List<Caixa>> ListaCaixas(int mes = 99);
    }
}
