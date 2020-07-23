using meucaixa.Interfaces;
using meucaixa.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace meucaixa.Repositories
{
    class CaixaRepository : IRepository<Caixa>
    {
        readonly SQLiteAsyncConnection _sqlLiteAsyncConnection;

        public CaixaRepository()
        {
            _sqlLiteAsyncConnection = new SQLiteAsyncConnection(AppConstantes.DatabasePath);
            _sqlLiteAsyncConnection.CreateTableAsync<Caixa>();
        }

        public async Task AdicionaRegistro(Caixa entity)
        {
            await _sqlLiteAsyncConnection.InsertAsync(entity);
        }

        public async Task AlteraCaixaAsync(Caixa caixa)
        {
            await _sqlLiteAsyncConnection.UpdateAsync(caixa);
        }

        public async Task AlteraRegistro(Caixa entity)
        {
            await _sqlLiteAsyncConnection.UpdateAsync(entity);
        }

        public async Task<List<Caixa>> Lista()
        {
            return await _sqlLiteAsyncConnection.Table<Caixa>().ToListAsync();
        }

        public async Task<List<Caixa>> Lista(Expression<Func<Caixa, bool>> predicate)
        {
            return await _sqlLiteAsyncConnection.Table<Caixa>().Where(predicate).ToListAsync();
        }

        public async Task<Caixa> PrimeiroOuDefault(Expression<Func<Caixa, bool>> predicate)
        {
            return await _sqlLiteAsyncConnection.Table<Caixa>().FirstOrDefaultAsync(predicate);
        }

        public async Task<Caixa> SelecionaPorId(int id)
        {
            return await _sqlLiteAsyncConnection.Table<Caixa>().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
