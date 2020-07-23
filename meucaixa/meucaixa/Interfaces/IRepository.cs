using meucaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace meucaixa.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> SelecionaPorId(int id);
        Task<List<T>> Lista();
        Task<List<T>> Lista(Expression<Func<T, bool>> predicate);
        Task<T> PrimeiroOuDefault(Expression<Func<T, bool>> predicate);
        Task AdicionaRegistro(T entity);
        Task AlteraRegistro(T Entity);
    }
}
