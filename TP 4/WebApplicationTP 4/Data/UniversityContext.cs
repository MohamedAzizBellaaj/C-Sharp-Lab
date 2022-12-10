using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationTP_4.Models;

namespace WebApplicationTP_4.Data
{
	public class UniversityContext : DbContext
	{
		public DbSet<Student> Student { get; set; }
		private static UniversityContext Instance;

		private UniversityContext(DbContextOptions o) : base(o) { }
		private static UniversityContext Instantiate_UniversityContext()
		{
			Console.WriteLine("This is run.");
			var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
			optionsBuilder.UseSqlite("Data Source=.\\2022 GL3 .NET Framework TP4 - SQLite database.db;");
			return new UniversityContext(optionsBuilder.Options);
		}
		public static UniversityContext getInstance()
		{
			if (Instance is null)
			{
				Instance = Instantiate_UniversityContext();
			}
			return Instance;
		}
	}
}
