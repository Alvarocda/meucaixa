using meucaixa.Interfaces;
using meucaixa.Models;
using meucaixa.Utils;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace meucaixa.ViewModels
{
    public class CaixaViewModel : BaseViewModel
    {
        private bool _isBusy = false;
        private readonly Caixa _caixa;
        private readonly ICaixa _caixaService;
        private readonly IDespesas _despesasService;
        private string _totalDespesas;
        private readonly FormataDinheiro _formataDinheiro;

        private Color _corTotalMenosDespesa = Color.FromHex("#F6F7F8");
        private Color _corTotalMenosDespesaMenosProximoCaixa = Color.FromHex("#F6F7F8");

        public Command AddDespesaCommand { get; }
        public Command SalvarCaixaCommand { get; }
        public Command RemoveDespesaCommand { get; }
        public Command Salvar { get; }
        private readonly ISnackbar _snackbar;
        public CaixaViewModel()
        {
            Title = "Fechamento de caixa " + DateTime.Now.ToString("dd/MM/yyyy");
            AddDespesaCommand = new Command(async () => await AdicionaDespesa(), () => !IsBusy);
            RemoveDespesaCommand = new Command<Despesa>(async (despesa) => await RemoveDespesa(despesa));
            SalvarCaixaCommand = new Command(async () => await SalvaDespesa(), () => !IsBusy);

            using (AsyncScopedLifestyle.BeginScope(App.IoCContainer))
            {
                _caixaService = App.IoCContainer.GetInstance<ICaixa>();
                _despesasService = App.IoCContainer.GetInstance<IDespesas>();
            }
            _snackbar = DependencyService.Get<ISnackbar>();

            _formataDinheiro = new FormataDinheiro();
            _caixa = new Caixa();
            _caixa.Despesas = new ObservableCollection<Despesa>();

            _caixa.Despesas.CollectionChanged += _despesas_CollectionChanged;
        }

        private void _despesas_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CalculaTotal();
        }

        private async Task RemoveDespesa(Despesa despesa)
        {
            bool confirmaExclusao = await Application.Current.MainPage.DisplayAlert("Aviso", "Tem certeza que deseja remover a despesa selecionada?", "Sim", "Não");
            if (confirmaExclusao)
            {
                Despesas.Remove(despesa);
                _snackbar.MostraSnackbarCurto("Despesa removida com sucesso!");
            }
            else
            {
                _snackbar.MostraSnackbarCurto("Falha ao remover despesa");
            }
        }

        private async Task SalvaDespesa()
        {
            List<Caixa> teste = await _caixaService.ListaCaixas();
            try
            {
                await _caixaService.SalvaCaixa(_caixa);
                await _despesasService.SalvaDespesasAsync(_caixa);
                _snackbar.MostraSnackbarCurto("Caixa lançado com sucesso!");
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("OK", "Erro " + e.Message, "OK");
            }
        }
        private int SomaNotas2(int n) { return n * 2; }
        private int SomaNotas5(int n) { return n * 5; }
        private int SomaNotas10(int n) { return n * 10; }
        private int SomaNotas20(int n) { return n * 20; }
        private int SomaNotas50(int n) { return n * 50; }
        private int SomaNotas100(int n) { return n * 100; }

        private void CalculaTotal()
        {
            decimal totalStelo = 0;
            decimal totalCielo = 0;
            decimal total = 0;
            decimal totalMenosDespesas = 0;
            decimal totalMenosDespesasProximoCaixa = 0;
            decimal valorAberturaCaixa = 0;
            try
            {
                totalStelo = Convert.ToDecimal(TotalStelo);
            }
            catch (Exception)
            {

            }
            try
            {
                totalCielo = Convert.ToDecimal(TotalCielo);
            }
            catch (Exception)
            {

            }
            try
            {
                valorAberturaCaixa = Convert.ToDecimal(ValorAberturaNovoCaixa);
            }
            catch (Exception)
            {

            }
            total = TotalNotas2 + TotalNotas5 + TotalNotas10 + TotalNotas20 + TotalNotas50 + TotalNotas100 + totalStelo + totalCielo;
            totalMenosDespesas = total - Despesas.Sum(d => Convert.ToDecimal(d.Valor));
            totalMenosDespesasProximoCaixa = totalMenosDespesas - valorAberturaCaixa;
            if(totalMenosDespesas <= 0)
            {
                CorTotalMenosDespesa = Color.Red;
            }
            else
            {
                CorTotalMenosDespesa = Color.FromHex("#F6F7F8");
            }
            if (totalMenosDespesasProximoCaixa <= 0)
            {
                CorTotalMenosDespesaMenosProximoCaixa = Color.Red;
            }
            else
            {
                CorTotalMenosDespesaMenosProximoCaixa = Color.FromHex("#F6F7F8");
            }
            TotalDespesas = _formataDinheiro.FormataValor(_caixa.Despesas.Sum(d => Convert.ToDecimal(d.Valor)).ToString());
            Total = total.ToString();
            TotalMenosDespesas = totalMenosDespesas.ToString();
            TotalMenosDespesasMenosProximoCaixa = totalMenosDespesasProximoCaixa.ToString();
        }

        public ObservableCollection<Despesa> Despesas
        {
            get => _caixa.Despesas;
            set
            {
                _caixa.Despesas = value;
                OnPropertyChanged();
            }
        }
        private async Task AdicionaDespesa()
        {
            await Navigation.PushAsync<AddDespesaViewModel>(true, Despesas);
        }
        public string Notas2
        {
            get => _caixa.Notas2;
            set
            {
                _caixa.Notas2 = value;
                OnPropertyChanged();
                TotalNotas2 = string.IsNullOrEmpty(Notas2) ? 0 : SomaNotas2(Int32.Parse(Notas2));
                CalculaTotal();
            }
        }
        public string Notas5
        {
            get => _caixa.Notas5;
            set
            {
                _caixa.Notas5 = value;
                OnPropertyChanged();
                TotalNotas5 = string.IsNullOrEmpty(Notas5) ? 0 : SomaNotas5(Int32.Parse(Notas5));
                CalculaTotal();
            }
        }
        public string Notas10
        {
            get => _caixa.Notas10;
            set
            {
                _caixa.Notas10 = value;
                OnPropertyChanged();
                TotalNotas10 = string.IsNullOrEmpty(Notas10) ? 0 : SomaNotas10(Int32.Parse(Notas10));
                CalculaTotal();
            }
        }
        public string Notas20
        {
            get => _caixa.Notas20;
            set
            {
                _caixa.Notas20 = value;
                OnPropertyChanged();
                TotalNotas20 = string.IsNullOrEmpty(Notas20) ? 0 : SomaNotas20(Int32.Parse(Notas20));
                CalculaTotal();
            }
        }
        public string Notas50
        {
            get => _caixa.Notas50;
            set
            {
                _caixa.Notas50 = value;
                OnPropertyChanged();
                TotalNotas50 = string.IsNullOrEmpty(Notas50) ? 0 : SomaNotas50(Int32.Parse(Notas50));
                CalculaTotal();
            }
        }
        public string Notas100
        {
            get => _caixa.Notas100;
            set
            {
                _caixa.Notas100 = value;
                OnPropertyChanged();
                TotalNotas100 = string.IsNullOrEmpty(Notas100) ? 0 : SomaNotas100(Int32.Parse(Notas100));
                CalculaTotal();
            }
        }

        public int TotalNotas2
        {
            get => _caixa.TotalNotas2;
            set
            {
                _caixa.TotalNotas2 = value;
                OnPropertyChanged();
            }
        }
        public int TotalNotas5
        {
            get => _caixa.TotalNotas5;
            set
            {
                _caixa.TotalNotas5 = value;
                OnPropertyChanged();
            }
        }
        public int TotalNotas10
        {
            get => _caixa.TotalNotas10;
            set
            {
                _caixa.TotalNotas10 = value;
                OnPropertyChanged();
            }
        }
        public int TotalNotas20
        {
            get => _caixa.TotalNotas20;
            set
            {
                _caixa.TotalNotas20 = value;
                OnPropertyChanged();
            }
        }
        public int TotalNotas50
        {
            get => _caixa.TotalNotas50;
            set
            {
                _caixa.TotalNotas50 = value;
                OnPropertyChanged();
            }
        }
        public int TotalNotas100
        {
            get => _caixa.TotalNotas100;
            set
            {
                _caixa.TotalNotas100 = value;
                OnPropertyChanged();
            }
        }
        public string TotalCielo
        {
            get => _caixa.TotalCielo;
            set
            {
                _caixa.TotalCielo = _formataDinheiro.FormataValor(value);
                OnPropertyChanged();
                CalculaTotal();
            }
        }
        public string TotalStelo
        {
            get => _caixa.TotalStelo;
            set
            {
                _caixa.TotalStelo = _formataDinheiro.FormataValor(value);
                OnPropertyChanged();
                CalculaTotal();
            }
        }

        public string Total
        {
            get => _caixa.Total;
            set
            {
                _caixa.Total = _formataDinheiro.FormataValor(value);
                OnPropertyChanged();
            }
        }
        public string TotalMenosDespesas
        {
            get => _caixa.TotalMenosDespesas;
            set
            {
                _caixa.TotalMenosDespesas = _formataDinheiro.FormataValor(value);
                OnPropertyChanged();
            }
        }
        public string TotalMenosDespesasMenosProximoCaixa
        {
            get => _caixa.TotalMenosDespesasMenosProximoCaixa;
            set
            {
                _caixa.TotalMenosDespesasMenosProximoCaixa = _formataDinheiro.FormataValor(value);
                OnPropertyChanged();
            }
        }
        public string ValorAberturaNovoCaixa
        {
            get => _caixa.ValorAberturaNovoCaixa;
            set
            {
                _caixa.ValorAberturaNovoCaixa = _formataDinheiro.FormataValor(value);
                OnPropertyChanged();
                CalculaTotal();
            }
        }
        public string TotalDespesas
        {
            get => _totalDespesas;
            set
            {
                _totalDespesas = _formataDinheiro.FormataValor(value);
                OnPropertyChanged();
            }
        }
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                AddDespesaCommand.ChangeCanExecute();
                RemoveDespesaCommand.ChangeCanExecute();
                SalvarCaixaCommand.ChangeCanExecute();
            }
        }
        public Color CorTotalMenosDespesa
        {
            get => _corTotalMenosDespesa;
            set {
                _corTotalMenosDespesa = value;
                OnPropertyChanged();
            }
        }

        public Color CorTotalMenosDespesaMenosProximoCaixa
        {
            get => _corTotalMenosDespesaMenosProximoCaixa;
            set
            {
                _corTotalMenosDespesaMenosProximoCaixa = value;
                OnPropertyChanged();
            }
        }
    }
}
