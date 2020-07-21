
namespace meucaixa.Models
{
    public class Despesa
    {
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public int CaixaId { get; set; }
        [SQLite.Ignore]
        public Caixa Caixa { get; set; }
    }
}
