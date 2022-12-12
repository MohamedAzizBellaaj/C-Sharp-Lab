using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationTP_4.Models;

namespace WebApplicationTP_4.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student>? Student { get; set; }
        private static UniversityContext? _instance;
        public static UniversityContext Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = Instantiate_UniversityContext();
                }
                return _instance;
            }
        }

        private UniversityContext(DbContextOptions o) : base(o) { }
        private static UniversityContext Instantiate_UniversityContext()
        {
            Debug.WriteLine("This is run.");
            var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
            optionsBuilder.UseSqlite("Data Source=.\\2022 GL3 .NET Framework TP4 - SQLite database.db;");
            return new UniversityContext(optionsBuilder.Options);
        }
    }
}
