using meucaixa.Interfaces;
using meucaixa.Models;
using Microcharts;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace meucaixa.ViewModels
{
    public class HistoricoViewModel : BaseViewModel
    {
        ObservableCollection<ChartEntry> _chartEntries;
        readonly ICaixa _caixaService;
        readonly IDespesa _despesaService;
        BarChart _charts;
        public HistoricoViewModel()
        {
            ChartsEntries = new ObservableCollection<ChartEntry>();
            using (AsyncScopedLifestyle.BeginScope(App.IoCContainer))
            {
                _caixaService = App.IoCContainer.GetInstance<ICaixa>();
                _despesaService = App.IoCContainer.GetInstance<IDespesa>();
            }
            Task.Run(async () => await CarregaCaixas());
        }

        private async Task CarregaCaixas()
        {
            List<Caixa> caixas = await _caixaService.ListaCaixas(DateTime.Now.Month);
            foreach(Caixa cx in caixas)
            {
                float valorTotal = 0.0f;
                try
                {
                    valorTotal = float.Parse(cx.TotalMenosDespesasMenosProximoCaixa);
                }
                catch (Exception)
                {

                }
                ChartsEntries.Add(new ChartEntry(valorTotal) { Label = cx.DataCaixa.ToString("dd/MM/yyyy"), ValueLabel = valorTotal.ToString()});
            }
            Charts = new BarChart() { Entries = ChartsEntries };
        }

        public BarChart Charts
        {
            get => _charts;
            set
            {
                _charts = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ChartEntry> ChartsEntries
        {
            get => _chartEntries;
            set
            {
                _chartEntries = value;
                OnPropertyChanged();
            }
        }
    }
}
