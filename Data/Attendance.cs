using SQLite;

namespace EdUnity.Data
{
	[Table("attendances")]
	public class Attendance
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		[NotNull]
		public int USER_ID { get; set; }
		[NotNull]
		public string DATE { get; set; }
		[NotNull]
		public AttendanceStatus STATUS { get; set; }
	}
	public enum AttendanceStatus
	{
		Present,
		Absent,
		Tardy
	}
}
