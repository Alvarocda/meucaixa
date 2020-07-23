using meucaixa.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace meucaixa.ViewModels
{
    public class PrincipalViewModel : BaseViewModel
    {
        public Command AbreFechamentoCaixaCommand { get; }
        public Command AbreHistoricoCommand { get; }
        public Command SairCommand { get; }
        private IAndroid _android;
        public PrincipalViewModel()
        {
            AbreFechamentoCaixaCommand = new Command(async () => await AbreFechamentoCaixa());
            AbreHistoricoCommand = new Command(async () => await AbreHistorico());
            SairCommand = new Command(async () => await Sair());
            _android = DependencyService.Get<IAndroid>();
        }

        private async Task AbreFechamentoCaixa()
        {
            await Navigation.PushAsync<CaixaViewModel>();
        }

        private async Task AbreHistorico()
        {
            await Navigation.PushAsync<HistoricoViewModel>();
        }

        private async Task Sair()
        {
            bool confirmaSaida = await Application.Current.MainPage.DisplayAlert("Aviso", "Deseja realmente sair?", "Sim", "Não");
            if (confirmaSaida)
            {
                _android.FechaApp();
            }
        }
    }
}
