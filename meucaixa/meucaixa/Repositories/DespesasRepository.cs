using meucaixa.Interfaces;
using meucaixa.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace meucaixa.Repositories
{
    class DespesasRepository : IDespesaRepository<Despesa>
    {
        readonly SQLiteAsyncConnection _sQLiteAsyncConnection;
        public DespesasRepository()
        {
            _sQLiteAsyncConnection = new SQLiteAsyncConnection(AppConstantes.DatabasePath);
            _sQLiteAsyncConnection.CreateTableAsync<Despesa>();
        }

        public async Task AdicionaDespesas(ObservableCollection<Despesa> despesas)
        {
            await _sQLiteAsyncConnection.InsertAllAsync(despesas);
        }

        public async Task AlteraRegistro(Despesa entity)
        {
            await _sQLiteAsyncConnection.UpdateAsync(entity);
        }

        public async Task<List<Despesa>> Lista()
        {
            return await _sQLiteAsyncConnection.Table<Despesa>().ToListAsync();
        }

        public async Task<List<Despesa>> Lista(Expression<Func<Despesa, bool>> predicate)
        {
            return await _sQLiteAsyncConnection.Table<Despesa>().Where(predicate).ToListAsync();
        }

        public async Task<Despesa> PrimeiroOuDefault(Expression<Func<Despesa, bool>> predicate)
        {
            return await _sQLiteAsyncConnection.Table<Despesa>().FirstOrDefaultAsync(predicate);
        }

        public async Task<Despesa> SelecionaPorId(int id)
        {
            return await _sQLiteAsyncConnection.Table<Despesa>().FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
