using SQLite;

namespace EdUnity.Data
{
	[Table("schools")]
	public class Institution
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		[NotNull]
		public int NCESID { get; set; }
		[NotNull]
		public string NAME { get; set; }
		public string ADDRESS { get; set; }
		public string CITY { get; set; }
		public string STATE { get; set; }
		public int ZIP { get; set; }
		public int ZIP4 { get; set; }
		public string TELEPHONE { get; set; }
		public int TYPE { get; set; }
		public int STATUS { get; set; }
		public int POPULATION { get; set; }
		public string COUNTY { get; set; }
		public int COUNTYFIPS { get; set; }
		public string COUNTRY { get; set; }
		public float LATITUDE { get; set; }
		public float LONGITUDE { get; set; }
		public int NAICS_CODE { get; set; }
		public string NAICS_DESC { get; set; }
		public string SOURCE { get; set; }
		public string LEVEL { get; set; }
		public int ENROLLMENT { get; set; }
		public string START_GRADE { get; set; }
		public string END_GRADE { get; set; }
		public int FT_TEACHER { get; set; }
	}
}
