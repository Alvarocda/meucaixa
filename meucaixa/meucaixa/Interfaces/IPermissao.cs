using System.Threading.Tasks;
using Xamarin.Essentials;

namespace meucaixa.Interfaces
{
    public interface IPermissao
    {
        Task<bool> VerificaESolicitaPermissao<T>(T permission) where T : Permissions.BasePermission;
    }
}
