using meucaixa.Interfaces;
using meucaixa.Models;
using Microcharts;
using SimpleInjector.Lifestyles;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace meucaixa.ViewModels
{
    public class HistoricoViewModel : BaseViewModel
    {
        readonly ICaixa _caixaService;
        Chart _chart;
        public HistoricoViewModel()
        {
            using (AsyncScopedLifestyle.BeginScope(App.IoCContainer))
            {
                _caixaService = App.IoCContainer.GetInstance<ICaixa>();
            }
            Task.Run(async () =>
            {
                await CarregaDespesas();
            });
        }
        private async Task CarregaDespesas()
        {
            List<Caixa> caixas = await _caixaService.ListaCaixas();
            List<ChartEntry> chartEntries = new List<ChartEntry>();
            
            foreach (Caixa cx in caixas)
            {
                float total = 0.0f;
                try
                {
                    total = float.Parse(cx.TotalMenosDespesasMenosProximoCaixa);
                }
                finally
                {
                    chartEntries.Add(
                        new ChartEntry(total)
                        {
                            Label = cx.DataCaixa.ToString("dd/MM/yyyy"),
                            ValueLabel = $"R$ {cx.TotalMenosDespesasMenosProximoCaixa}",
                            Color = total < 0.0f ? SKColor.Parse("#FF3366") : SKColor.Parse("#28502E")
                        }
                    );
                    Chart = new BarChart
                    {
                        Entries = chartEntries,
                        LabelTextSize = 45,
                        ValueLabelOrientation = Orientation.Horizontal,
                        Margin = 60
                    };
                }
            }
        }

        public Chart Chart
        {
            get => _chart;
            set
            {
                _chart = value;
                OnPropertyChanged();
            }
        }
    }
}
