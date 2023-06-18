using SQLite;

namespace EdUnity.Data
{
	[Table("events")]
	public class Event
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		[NotNull]
		public string TITLE { get; set; }
		public string DESCRIPTION { get; set; }
		[NotNull]
		public string START { get; set; }
		[NotNull]
		public string END { get; set; }
		[NotNull]
		public EventType TYPE { get; set; }
		[NotNull]
		public int CREATOR_ID { get; set; }
	}
	public enum EventType
	{
		Academic,
		Athletics,
		Celebration,
		Ceremony,
		Clubs,
		Holiday,
		Meeting,
		Trip,
		Other
	}
}
