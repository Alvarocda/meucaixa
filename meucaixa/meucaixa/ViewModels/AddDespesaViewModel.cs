using meucaixa.Interfaces;
using meucaixa.Models;
using meucaixa.Utils;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace meucaixa.ViewModels
{
    class AddDespesaViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Despesa> _despesas;
        public Command AddDespesaCommand { get; }
        private readonly Despesa _despesa;
        private readonly FormataDinheiro _formataDinheiro;
        readonly ISnackbar _snackbar;
        readonly IDespesas _despesaService;
        public AddDespesaViewModel(ObservableCollection<Despesa> despesas)
        {
            _despesas = despesas;
            _despesaService = App.IoCContainer.GetInstance<IDespesas>();
            _snackbar = DependencyService.Get<ISnackbar>();
            AddDespesaCommand = new Command(async () => await AddDespesa(), () => !IsBusy);
            _formataDinheiro = new FormataDinheiro();
            _despesa = new Despesa();
        }

        private async Task AddDespesa()
        {
            try
            {
                decimal valor = Convert.ToDecimal(Valor);
                if (!string.IsNullOrEmpty(Descricao) && valor > 0)
                {
                    _despesas.Add(_despesa);
                    AddDespesaCommand.ChangeCanExecute();
                    _snackbar.MostraSnackbarCurto("Despesa adicionada com sucesso!");
                    await Navigation.PopAsync(true);
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Erro", "Por favor, informe um valor e uma descrição para a despesa", "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Por favor, informe um valor valido", "OK");
            }
            
        }

        public string Descricao
        {
            get => _despesa.Descricao;
            set
            {
                _despesa.Descricao = value;
                OnPropertyChanged();
            }
        }

        public string Valor
        {
            get => _despesa.Valor;
            set
            {
                _despesa.Valor =  _formataDinheiro.FormataValor(value);
                OnPropertyChanged();
            }
        }


    }
}
