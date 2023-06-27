using SQLite;

namespace EdUnity.Data
{
	[Table("courses")]
	public class Course
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		[NotNull]
		public string NAME { get; set; }
	}
}
