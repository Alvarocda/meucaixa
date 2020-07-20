
namespace meucaixa.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public int CaixaId { get; set; }
        public Caixa Caixa { get; set; }
    }
}
