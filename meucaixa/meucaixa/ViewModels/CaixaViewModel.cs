using meucaixa.Models;
using Xamarin.Forms;

namespace meucaixa.ViewModels
{
    public class CaixaViewModel : BaseViewModel
    {

        Caixa _caixa;
        public Command AddDespesa { get; }
        public Command Salvar { get; }
        public CaixaViewModel()
        {
            _caixa = new Caixa();
        }

        private int SomaNotas2(int n) { return n * 2; }
        private int SomaNotas5(int n) { return n * 5; }
        private int SomaNotas10(int n) { return n * 10; }
        private int SomaNotas20(int n) { return n * 20; }
        private int SomaNotas50(int n) { return n * 50; }
        private int SomaNotas100(int n) { return n * 100; }

        private void CalculaTotal()
        {
            Total = TotalNotas2 + TotalNotas5 + TotalNotas10 + TotalNotas20 + TotalNotas50 + TotalNotas100 + TotalStelo + TotalCielo;
            TotalMenosDespesas = Total - 125;
            TotalMenosDespesasMenosProximoCaixa = TotalMenosDespesas - 250;

        }

        public int Notas2 {
            get => _caixa.Notas2;
            set
            {
                _caixa.Notas2 = value;
                OnPropertyChanged();
                TotalNotas2 = SomaNotas2(Notas2);
                CalculaTotal();
            }
        }
        public int Notas5
        {
            get => _caixa.Notas5;
            set
            {
                _caixa.Notas5 = value;
                OnPropertyChanged();
                TotalNotas5 = SomaNotas5(Notas5);
                CalculaTotal();
            }
        }
        public int Notas10
        {
            get => _caixa.Notas10;
            set
            {
                _caixa.Notas10 = value;
                OnPropertyChanged();
                TotalNotas10 = SomaNotas10(Notas10);
                CalculaTotal();
            }
        }
        public int Notas20
        {
            get => _caixa.Notas20;
            set
            {
                _caixa.Notas20 = value;
                OnPropertyChanged();
                TotalNotas20 = SomaNotas20(Notas20);
                CalculaTotal();
            }
        }
        public int Notas50
        {
            get => _caixa.Notas50;
            set
            {
                _caixa.Notas50 = value;
                OnPropertyChanged();
                TotalNotas50 = SomaNotas50(Notas50);
                CalculaTotal();
            }
        }
        public int Notas100
        {
            get => _caixa.Notas100;
            set
            {
                _caixa.Notas100 = value;
                OnPropertyChanged();
                TotalNotas100= SomaNotas100(Notas100);
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
        public decimal TotalCielo
        {
            get => _caixa.TotalCielo;
            set
            {
                _caixa.TotalCielo = value;
                OnPropertyChanged();
                CalculaTotal();
            }
        }
        public decimal TotalStelo
        {
            get => _caixa.TotalStelo;
            set
            {
                _caixa.TotalStelo = value;
                OnPropertyChanged();
                CalculaTotal();
            }
        }

        public decimal Total
        {
            get => _caixa.Total;
            set
            {
                _caixa.Total = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalMenosDespesas
        {
            get => _caixa.TotalMenosDespesas;
            set
            {
                _caixa.TotalMenosDespesas = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalMenosDespesasMenosProximoCaixa
        {
            get => _caixa.TotalMenosDespesasMenosProximoCaixa;
            set
            {
                _caixa.TotalMenosDespesasMenosProximoCaixa = value;
                OnPropertyChanged();
            }
        }
    }
}
