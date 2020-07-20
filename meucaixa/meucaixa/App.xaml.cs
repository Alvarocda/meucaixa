using meucaixa.Interfaces;
using meucaixa.Repositories;
using meucaixa.Services;
using meucaixa.Views;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Xamarin.Forms;

namespace meucaixa
{
    public partial class App : Application
    {
        private static Container ioCContainer = new SimpleInjector.Container();
        public App()
        {
            InitializeComponent();
            App.IoCContainer.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            App.IoCContainer.Register<ICaixa, CaixaService>(Lifestyle.Scoped);
            App.IoCContainer.Register<IDespesas, DespesaService>(Lifestyle.Scoped);
            App.IoCContainer.Register<ICaixaRepository, CaixaRepository>(Lifestyle.Scoped);
            App.IoCContainer.Register<IDespesasRepository, DespesasRepository>(Lifestyle.Scoped);
            /* DependencyService.Register<ICaixa, CaixaService>();
            DependencyService.Register<IDespesas, DespesaService>();*/
            MainPage = new NavigationPage(new CaixaPage());
        }
        public static Container IoCContainer
        {
            get => ioCContainer;
            set => ioCContainer = value;
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
