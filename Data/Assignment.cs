using SQLite;

namespace EdUnity.Data
{
	[Table("assignments")]
	public class Assignment
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		[NotNull]
		public string NAME { get; set; }
		[NotNull]
		public string DUEDATE { get; set; }
		[NotNull]
		public int GRADE { get; set; }
		[NotNull]
		public int COURSE_ID { get; set; }
	}
}
