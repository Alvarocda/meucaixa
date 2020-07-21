using meucaixa.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace meucaixa.Services
{
    class LogService : ILog
    {
        readonly IPermissao _permissao;
        public LogService(IPermissao permissao)
        {
            _permissao = permissao;
        }
        public async Task EscreveLog(string log)
        {
            bool permissaoEscrita = await _permissao.VerificaESolicitaPermissao(new Permissions.StorageWrite());
            if (permissaoEscrita)
            {
                using (StreamWriter escritor = new StreamWriter(AppConstantes.LogFilePath))
                {
                    string erro = $"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - {log}";
                    await escritor.WriteLineAsync(erro);
                }
            }
        }

        public async Task EscreveLog(string log, Exception e)
        {
            bool permissaoEscrita = await _permissao.VerificaESolicitaPermissao(new Permissions.StorageWrite());
            if (permissaoEscrita)
            {
                using (StreamWriter escritor = new StreamWriter(AppConstantes.LogFilePath))
                {
                    string erro = $"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - {log}\r\nException: {e.Message}\r\n";
                    await escritor.WriteLineAsync(erro);
                }
            }
        }
    }
}
