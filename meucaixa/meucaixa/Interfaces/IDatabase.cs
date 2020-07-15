using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meucaixa.Interfaces
{
    public interface IDatabase
    {
        Task SalvaNoBanco<T>(T obj);
    }
}
