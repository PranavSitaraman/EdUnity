using SQLite;
using EdUnity.Data;
using System.Data;
using System.Linq;

namespace EdUnity
{
	public class EdUnityRepository
	{
		private string _dbPath;
		private User user;
		private Institution institution;

		public string StatusMessage { get; set; }
		private SQLiteAsyncConnection conn;

		public EdUnityRepository(string dbPath)
		{
			_dbPath = dbPath;
		}
		private async Task Init()
		{
			if (conn != null)
			{
				return;
			}
			conn = new SQLiteAsyncConnection(_dbPath);
			await conn.CreateTablesAsync<User, Event, Institution, Photo, Game>();
			await conn.CreateTablesAsync<Course, Assignment, Attendance>();
			try
			{
				await AddData.CreateUsers(conn);
				await AddData.CreateSchools(conn);
				await AddData.CreateEvents(conn);
				await AddData.CreatePhotos(conn);
				await AddData.CreateGames(conn);
				await AddData.CreateCourses(conn);
				await AddData.CreateAssignments(conn);
				await AddData.CreateAttendance(conn);
			}
			catch (Exception ex) {; }
		}

		// users table operations
		// retrieve user during login or check during registration
		public async Task<User> GetUser(string email)
		{
			await Init();
			return await (from u in conn.Table<User>() where u.EMAIL == email select u).FirstOrDefaultAsync();
		}
		// retrieve user in-app
		public async Task<User> GetUser(int id)
		{
			await Init();
			return await (from u in conn.Table<User>() where u.ID == id select u).FirstOrDefaultAsync();
		}
		// create new user after successful registration
		public async Task<bool> AddUser(User u)
		{
			await Init();
			if ((await GetUser(u.EMAIL)) != null)
			{
				return false;
			}
			await conn.InsertAsync(u);
			return true;
		}
		// change user's password
		public async Task<bool> UpdateUser(string newPassword)
		{
			await Init();
			user.PASSWORD = newPassword;
			await conn.UpdateAsync(user);
			return true;
		}
		// set current user
		public async Task<bool> SetUser(int id)
		{
			await Init();
			user = await GetUser(id);
			if (user == null)
			{
				return false;
			}
			institution = await (from s in conn.Table<Institution>() where s.ID == user.INSTITUTION_ID select s).FirstOrDefaultAsync();
			return true;
		}
		// get current user
		public User GetCurrentUser()
		{
			return user;
		}
		// get user count
		public async Task<int> GetUserCount()
		{
			await Init();
			return await conn.Table<User>().CountAsync();
		}

		// events table operations
		// create new event
		public async Task<bool> AddEvent(Event e)
		{
			await Init();
			await conn.InsertAsync(e);
			return true;
		}
		// get all existing events
		public async Task<List<Event>> GetEvents(DateTime month)
		{
			await Init();
			// events that start in this month, or events who started before this month and end after the start of this month
			// only show events created by this user, an administrator from their institution, or their child if the user is a parent
			List<Event> events = new();
			foreach (Event e in (await conn.Table<Event>().ToListAsync()))
			{
				var creator = await GetUser(e.CREATOR_ID);
				if (creator.ID == user.ID || (creator.ROLE == AccountType.ADMINISTRATOR && creator.INSTITUTION_ID == user.INSTITUTION_ID) || (user.CHILD_ID == creator.ID))
				{
					events.Add(e);
				}
			}
			return events;
		}

		// schools table operations
		// get current user's institution
		public Institution GetCurrentInstitution()
		{
			return institution;
		}
		// retrieve institution using ID
		public async Task<Institution> GetInstitution(int id)
		{
			await Init();
			return await (from s in conn.Table<Institution>() where s.ID == id select s).FirstOrDefaultAsync();
		}
		// retrieve institution using name
		public async Task<Institution> GetInstitution(string name)
		{
			await Init();
			return await (from s in conn.Table<Institution>() where s.NAME == name select s).FirstOrDefaultAsync();
		}
		// autocomplete suggestor
		public async Task<List<Institution>> SuggestInstitutions(string searchTerm)
		{
			await Init();
			return await conn.Table<Institution>().Where(s => s.NAME.StartsWith(searchTerm)).Take(5).ToListAsync();
		}

		// photos table operations
		// get all photos
		public async Task<List<Photo>> GetPhotos()
		{
			await Init();
			return await conn.Table<Photo>().ToListAsync();
		}
		public async Task<bool> AddPhoto(Photo p)
		{
			await Init();
			await conn.InsertAsync(p);
			return true;
		}

		// athletics table operations
		// get all games
		public async Task<List<Game>> GetGames()
		{
			await Init();
			return await conn.Table<Game>().ToListAsync();
		}

		// courses table operations
		// get all courses
		public async Task<List<Course>> GetCourses()
		{
			await Init();
			return await conn.Table<Course>().ToListAsync();
		}

		// assignments table operations
		// get all assignments
		public async Task<List<Assignment>> GetAssignments()
		{
			await Init();
			return await conn.Table<Assignment>().ToListAsync();
		}

		public async Task<Attendance> GetAttendance(string d)
		{
			await Init();
			return await (from a in conn.Table<Attendance>() where a.DATE.Equals(d) select a).FirstOrDefaultAsync();
		}
	}
}