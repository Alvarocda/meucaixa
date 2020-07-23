using SQLite;

namespace meucaixa.Models
{
    public abstract class EntityBase
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
