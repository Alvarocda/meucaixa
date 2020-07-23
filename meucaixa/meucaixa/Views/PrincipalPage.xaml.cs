using meucaixa.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace meucaixa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalPage : ContentPage
    {
        public PrincipalPage()
        {
            InitializeComponent();
            BindingContext = new PrincipalViewModel();
        }
    }
}