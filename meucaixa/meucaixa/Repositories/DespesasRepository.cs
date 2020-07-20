using meucaixa.Interfaces;
using meucaixa.Models;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace meucaixa.Repositories
{
    class DespesasRepository : IDespesasRepository
    {
        readonly SQLiteAsyncConnection _sQLiteAsyncConnection;
        public DespesasRepository()
        {
            _sQLiteAsyncConnection = new SQLiteAsyncConnection(AppConstantes.DatabasePath);
            _sQLiteAsyncConnection.CreateTableAsync<Despesa>();
        }
        public async Task AdicionaDespesaAsync(ObservableCollection<Despesa> despesa)
        {
            await _sQLiteAsyncConnection.InsertAllAsync(despesa);
        }

        public async Task AlteraDespesaAsync(Despesa despesa)
        {
            await _sQLiteAsyncConnection.UpdateAsync(despesa);
        }

        public async Task<List<Despesa>> ListaDespesas(int caixaId = 0)
        {
            if (caixaId > 0)
            {
                return await _sQLiteAsyncConnection.Table<Despesa>()
                    .Where(d => d.CaixaId == caixaId)
                    .ToListAsync();
            }
            return await _sQLiteAsyncConnection
                .Table<Despesa>()
                .ToListAsync();
        }


        public async Task<Despesa> SelecionaDespesa(int id)
        {
            return await _sQLiteAsyncConnection.Table<Despesa>().FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
