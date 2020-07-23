using meucaixa.Interfaces;
using meucaixa.Models;
using meucaixa.Repositories;
using meucaixa.Services;
using meucaixa.Views;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
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
            App.IoCContainer.Register<IDespesa, DespesaService>(Lifestyle.Scoped);
            App.IoCContainer.Register<IRepository<Caixa>, CaixaRepository>(Lifestyle.Scoped);
            App.IoCContainer.Register<IDespesaRepository<Despesa>, DespesasRepository>(Lifestyle.Scoped);
            App.IoCContainer.Register<IPermissao, PermissaoService>(Lifestyle.Scoped);
            MainPage = new NavigationPage(new PrincipalPage());
        }
        public static Container IoCContainer
        {
            get => ioCContainer;
            set => ioCContainer = value;
        }
        protected override void OnStart()
        {
            Console.WriteLine("A");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("A");
        }

        protected override void OnResume()
        {
        }
    }
}
