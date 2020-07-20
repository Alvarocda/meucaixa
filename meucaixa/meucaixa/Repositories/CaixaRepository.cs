using meucaixa.Interfaces;
using meucaixa.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace meucaixa.Repositories
{
    class CaixaRepository : ICaixaRepository
    {
        readonly SQLiteAsyncConnection _sqlLiteAsyncConnection;

        public CaixaRepository()
        {
            _sqlLiteAsyncConnection = new SQLiteAsyncConnection(AppConstantes.DatabasePath);
            _sqlLiteAsyncConnection.CreateTableAsync<Caixa>();
        }

        public async Task AdicionaCaixaAsync(Caixa caixa)
        {
            await _sqlLiteAsyncConnection.InsertAsync(caixa);
        }

        public async Task AlteraCaixaAsync(Caixa caixa)
        {
            await _sqlLiteAsyncConnection.UpdateAsync(caixa);
        }

        public async Task<List<Caixa>> ListaCaixasAsync(int mes = 99)
        {
            if (mes < 99)
            {
                return await _sqlLiteAsyncConnection.Table<Caixa>()
                    .Where(c => c.DataCaixa.Month == mes)
                    .ToListAsync();
            }
            return await _sqlLiteAsyncConnection.Table<Caixa>().ToListAsync();
        }

        public async Task<Caixa> SelecionaCaixaAsync(int id)
        {
            return await _sqlLiteAsyncConnection.Table<Caixa>().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
