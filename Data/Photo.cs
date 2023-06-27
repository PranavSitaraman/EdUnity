using SQLite;

namespace EdUnity.Data
{
    [Table("photos")]
    public class Photo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        [NotNull]
        public string PATH { get; set; }
    }
}
