using meucaixa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace meucaixa.Interfaces
{
    public interface IDespesaRepository<T> where T : Despesa
    {
        Task AdicionaDespesas(ObservableCollection<Despesa> despesas);
        Task<T> SelecionaPorId(int id);
        Task<List<T>> Lista();
        Task<List<T>> Lista(Expression<Func<T, bool>> predicate);
        Task<T> PrimeiroOuDefault(Expression<Func<T, bool>> predicate);
        Task AlteraRegistro(T Entity);
    }
}
