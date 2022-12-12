using WebApplicationTP_4.Models;

namespace WebApplicationTP_4.Data
{
	public interface IStudentRepository : IRepository<Student>
	{
		IEnumerable<Student>? GetStudentsByCourse(String course);
		IEnumerable<String> GetUniqueCourses();
	}
}
