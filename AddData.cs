﻿using SQLite;
using EdUnity.Data;

namespace EdUnity
{
	public static class AddData
	{
		public static async Task CreateUsers(SQLiteAsyncConnection conn)
		{
			string query = "INSERT INTO users (ID, FIRST_NAME, LAST_NAME, EMAIL, PASSWORD, INSTITUTION_ID, ROLE, CHILD_ID) VALUES(1, 'Jude', 'Bellingham', 'jude@edunity.org', 'jude', 37145, 0, -1);INSERT INTO users (ID, FIRST_NAME, LAST_NAME, EMAIL, PASSWORD, INSTITUTION_ID, ROLE, CHILD_ID) VALUES(2, 'Harry', 'Kane', 'harry@edunity.org', 'harry', 37145, 1, 1);INSERT INTO users (ID, FIRST_NAME, LAST_NAME, EMAIL, PASSWORD, INSTITUTION_ID, ROLE, CHILD_ID) VALUES(3, 'John', 'Stones', 'john@edunity.org', 'john', 37145, 2, -1);INSERT INTO users (ID, FIRST_NAME, LAST_NAME, EMAIL, PASSWORD, INSTITUTION_ID, ROLE, CHILD_ID) VALUES(4, 'Nick', 'Pope', 'nick@edunity.org', 'nick', 37145, 3, -1);";
			string[] queries = query.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string q in queries)
			{
				await conn.ExecuteAsync(q);
			}
		}

		public static async Task CreateEvents(SQLiteAsyncConnection conn)
		{
			string query = "INSERT INTO events (ID, TITLE, DESCRIPTION, START, END, TYPE, CREATOR_ID) VALUES(1, 'Marathon', NULL, '6/7/2023 12:00:00 AM', '6/7/2023 12:00:00 AM', 1, 4);INSERT INTO events (ID, TITLE, DESCRIPTION, START, END, TYPE, CREATOR_ID) VALUES(2, 'Marathon', NULL, '6/8/2023 12:00:00 AM', '6/8/2023 12:00:00 AM', 1, 4);";
			string[] queries = query.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string q in queries)
			{
				await conn.ExecuteAsync(q);
			}
		}

		public static async Task CreateSchools(SQLiteAsyncConnection conn)
		{
			string query = "INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(13308, 341000000000, 'MIDDLESEX COUNTY VOCATIONAL SCHOOL PISCATAWAY', '21 SUTTONS LANE', 'PISCATAWAY', 'NJ', 8854, 5715, '(732) 985-0717', 3, 1, 434, 'MIDDLESEX', 34023, 'USA', 40.52526889, -74.42783734, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=341008003426', 'HIGH', 391, '9', '12', 43);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(24344, 510000000000, 'MIDDLESEX HIGH', '454 GENERAL PULLER HIGHWAY', 'SALUDA', 'VA', 23149, NULL, '(804) 758-2132', 1, 1, 427, 'MIDDLESEX', 51119, 'USA', 37.60785672, -76.60222223, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=510249001012', 'HIGH', 395, '9', '12', 32);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(26959, 361000000000, 'MIDDLESEX VALLEY ELEMENTARY SCHOOL', '149 RT 245', 'RUSHVILLE', 'NY', 14544, 9603, '(585) 554-3115', 1, 1, 340, 'YATES', 36123, 'USA', 42.75510941, -77.24009718, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=361230000994', 'ELEMENTARY', 316, 'PK', '2', 24);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(27498, 341000000000, 'MIDDLESEX HIGH SCHOOL', '300 JOHN F. KENNEDY DRIVE', 'MIDDLESEX', 'NJ', 8846, 1489, '(732) 317-6000', 1, 1, 695, 'MIDDLESEX', 34023, 'USA', 40.58305867, -74.49515572, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=341005003404', 'HIGH', 635, '9', '12', 60);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(29288, 421000000000, 'MIDDLESEX EL SCH', '250 N MIDDLESEX RD', 'CARLISLE', 'PA', 17013, 8401, '(717) 697-2362', 1, 1, 427, 'CUMBERLAND', 42041, 'USA', 40.25586487, -77.14266708, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=420711001697', 'ELEMENTARY', 394, 'KG', '5', 33);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(37145, 341000000000, 'MIDDLESEX COUNTY VOC ACADEMY MATH SCIENCE &ENGINEERING TECHN', '100 TECHNOLOGY DRIVE', 'EDISON', 'NJ', 8837, NULL, '(732) 452-2600', 3, 1, 172, 'MIDDLESEX', 34023, 'USA', 40.50616311, -74.36952934, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=341008000395', 'HIGH', 159, '9', '12', 13);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(52799, 341000000000, 'MIDDLESEX COUNTY VOC ACAD ALLIED HEALTH & BIOMEDICAL SCIENCE', '1 CONVERY BOULEVARD', 'WOODBRIDGE', 'NJ', 7095, 2650, '(732) 634-5858', 3, 1, 288, 'MIDDLESEX', 34023, 'USA', 40.54175817, -74.27757038, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=341008003428', 'HIGH', 269, '8', '12', 19);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(62581, 341000000000, 'MIDDLESEX CO VOC SCHOOL EAST BRUNS. SCHOOL OF CAREER DEVELOP', '112 RUES LANE', 'EAST BRUNSWICK', 'NJ', 8816, 1070, '(732) 257-7715', 3, 1, 304, 'MIDDLESEX', 34023, 'USA', 40.42139491, -74.38532457, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=341008003176', 'HIGH', 278, '9', '12', 26);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(67872, 341000000000, 'MIDDLESEX CO VOC SCHOOL PISCATAWAY SCHOOL OF CAREER DEVELOP', '21 SUTTONS LANE', 'PISCATAWAY', 'NJ', 8854, NULL, '(732) 572-9494', 3, 1, 215, 'MIDDLESEX', 34023, 'USA', 40.52513628, -74.42756616, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=341008003177', 'HIGH', 195, '9', '12', 20);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(69095, 240000000000, 'MIDDLESEX ELEMENTARY', '142 BENNETT RD', 'BALTIMORE', 'MD', 21221, 1316, '(410) 887-0170', 1, 1, 544, 'BALTIMORE', 24005, 'USA', 39.32482984, -76.45282732, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=240012000430', 'ELEMENTARY', 509, 'PK', '5', 35);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(71011, 341000000000, 'MIDDLESEX COUNTY VOCATIONAL SCHOOL EAST BRUNSWICK', '112 RUES LANE', 'EAST BRUNSWICK', 'NJ', 8816, 4235, '(732) 254-8700', 3, 1, 455, 'MIDDLESEX', 34023, 'USA', 40.421859, -74.38509134, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=341008003420', 'HIGH', 417, '9', '12', 38);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(75945, 370000000000, 'MIDDLESEX ELEMENTARY', '13081 WEST HANES AVENUE', 'MIDDLESEX', 'NC', 27557, NULL, '(252) 462-2815', 1, 1, 392, 'NASH', 37127, 'USA', 35.78644828, -78.21311316, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=370327001348', 'ELEMENTARY', 366, 'PK', '5', 26);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(79459, 340000000000, 'MIDDLESEX CO YOUTH CTR', 'US HIGHWAY 130', 'NEW BRUNSWICK', 'NJ', 8902, NULL, '(732) 297-8991', 4, 1, 50, 'MIDDLESEX', 34023, 'USA', 40.4270838, -74.49104466, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=340008900681', 'HIGH', 50, '8', '12', NULL);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(84829, 510000000000, 'MIDDLESEX ELEMENTARY', '823 PHILPOT RD.', 'LOCUST HILL', 'VA', 23092, NULL, '(804) 758-2496', 1, 1, 629, 'MIDDLESEX', 51119, 'USA', 37.58865071, -76.50363691, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=510249002293', 'ELEMENTARY', 590, 'PK', '5', 39);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(85432, 90105000169, 'MIDDLESEX MIDDLE SCHOOL', '204 HOLLOW TREE RIDGE RD.', 'DARIEN', 'CT', 6820, 4023, '(203) 655-2518', 1, 1, 1236, 'FAIRFIELD', 9001, 'USA', 41.0736857, -73.4971977, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=090105000169', 'MIDDLE', 1123, '6', '8', 113);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(91827, 341000000000, 'MIDDLESEX COUNTY VOCATIONAL SCHOOL PERTH AMBOY', '457 HIGH STREET', 'PERTH AMBOY', 'NJ', 8861, NULL, '(732) 376-6300', 3, 1, 307, 'MIDDLESEX', 34023, 'USA', 40.51375867, -74.26278244, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=341008003424', 'HIGH', 285, '9', '12', 22);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(94862, 90353501731, 'MIDDLESEX TRANSITION ACADEMY', '279 COURT STREET', 'MIDDLETOWN', 'CT', 6457, NULL, '(860) 358-9583', 2, 2, NULL, 'MIDDLESEX', 9007, 'USA', 41.55858525, -72.65429117, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Public&ID=090353501731', 'HIGH', NULL, '12', '12', NULL);INSERT INTO schools (ID, NCESID, NAME, ADDRESS, CITY, STATE, ZIP, ZIP4, TELEPHONE, \"TYPE\", STATUS, POPULATION, COUNTY, COUNTYFIPS, COUNTRY, LATITUDE, LONGITUDE, NAICS_CODE, NAICS_DESC, \"SOURCE\", \"LEVEL\", ENROLLMENT, START_GRADE, END_GRADE, FT_TEACHER) VALUES(127374, 603698, 'MIDDLESEX SCHOOL', '1400 LOWELL RD', 'CONCORD', 'MA', 1742, 5255, NULL, 1, 2, 456, 'MIDDLESEX', 25017, 'USA', 42.49719636, -71.36867599, 611110, 'ELEMENTARY AND SECONDARY SCHOOLS', 'http://nces.ed.gov/GLOBALLOCATOR/sch_info_popup.asp?Type=Private&ID=00603698', '2', 375, '14', '17', 81);";
			string[] queries = query.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string q in queries)
			{
				await conn.ExecuteAsync(q);
			}
		}
	}
}