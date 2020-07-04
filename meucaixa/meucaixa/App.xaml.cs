using meucaixa.Views;
using Xamarin.Forms;

namespace meucaixa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CaixaPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
