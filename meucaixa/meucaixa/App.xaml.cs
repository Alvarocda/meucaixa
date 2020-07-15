using meucaixa.Interfaces;
using meucaixa.Models;
using meucaixa.Services;
using meucaixa.Views;
using SimpleInjector;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace meucaixa
{
    public partial class App : Application
    {
        private static Container ioCContainer = new SimpleInjector.Container();
        public App()
        {
            InitializeComponent();
            App.IoCContainer.Register<ICaixa, CaixaService>(Lifestyle.Transient);
            App.IoCContainer.Register<IDespesas, DespesaService>(Lifestyle.Transient);
            
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
