
namespace meucaixa.Models
{
    public class Despesa : EntityBase
    {
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public int CaixaId { get; set; }
        [SQLite.Ignore]
        public Caixa Caixa { get; set; }
    }
}
