using SQLite;

namespace EdUnity.Data
{
	[Table("games")]
	public class Game
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
        [NotNull]
		public Sport SPORT { get; set; }
		[NotNull]
		public string DATE { get; set; }
        [NotNull]
        public int TEAM_A { get; set; }
        [NotNull]
        public int TEAM_B { get; set; }
		[NotNull]
		public int SCORE_A { get; set; }
		[NotNull]
		public int SCORE_B { get; set; }
    }
	public enum Sport
	{
		Soccer,
		Football,
		Basketball,
		Hockey,
		Baseball
	}
}
