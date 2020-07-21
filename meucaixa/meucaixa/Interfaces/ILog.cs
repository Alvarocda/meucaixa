using System;
using System.Threading.Tasks;

namespace meucaixa.Interfaces
{
    public interface ILog
    {
        Task EscreveLog(string log);
        Task EscreveLog(string log, Exception e);
    }
}
