using WebApplicationTP_4.Models;

namespace WebApplicationTP_4.Data
{
	public class StudentRepository : Repository<Student>, IStudentRepository
	{
		private readonly UniversityContext _applicationDbContext;
		public StudentRepository(UniversityContext _applicationDbContext) : base(_applicationDbContext)
		{
			this._applicationDbContext = _applicationDbContext;
		}

		public IEnumerable<Student>? GetStudentsByCourse(string course)
		{
			return _applicationDbContext.Student.Where(student => student.course == course);
		}

		public IEnumerable<string> GetUniqueCourses()
		{
			return _applicationDbContext.Student.Select(student => student.course).ToHashSet();
		}
	}

}
