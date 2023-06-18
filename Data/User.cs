using SQLite;

namespace EdUnity.Data
{
	[Table("users")]
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		[NotNull]
		public string FIRST_NAME { get; set; }
		[NotNull]
		public string LAST_NAME { get; set; }
		[NotNull]
		public string EMAIL { get; set; }
		[NotNull]
		public string PASSWORD { get; set; }
		[NotNull]
		public int INSTITUTION_ID { get; set; }
		[NotNull]
		public AccountType ROLE { get; set; }
		public int CHILD_ID { get; set; }
	}

	public enum AccountType
	{
		STUDENT,
		PARENT,
		FACULTY,
		ADMINISTRATOR
	}
}
