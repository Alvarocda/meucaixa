using meucaixa.Interfaces;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace meucaixa.Services
{
    public class PermissaoService : IPermissao
    {
        public async Task<bool> VerificaESolicitaPermissao<T>(T permission) where T : Permissions.BasePermission
        {
            PermissionStatus permissionStatus = await VerificaPermissao<T>(permission);
            if (permissionStatus != PermissionStatus.Granted)
            {
                await Application.Current.MainPage.DisplayAlert("Permissão", "Nós precisamos da sua permissão para continuar, na proxima tela, clique em permitir!", "OK");
                permissionStatus = await permission.RequestAsync();
                if (permissionStatus != PermissionStatus.Granted)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

        }

        private async Task<PermissionStatus> VerificaPermissao<T>(T permission) where T : Permissions.BasePermission
        {
            return await permission.CheckStatusAsync();
        }
    }
}
