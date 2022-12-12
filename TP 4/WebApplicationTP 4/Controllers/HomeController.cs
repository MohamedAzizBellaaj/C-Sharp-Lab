using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationTP_4.Data;
using WebApplicationTP_4.Models;

namespace WebApplicationTP_4.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			//? Listing students
			UniversityContext u = UniversityContext.Instance;
			List<Student> s = u.Student.ToList();
			//foreach (Student student in s)
			//{
			//	Console.WriteLine(student);
			//}
			return View(s);
		}
		[Route("Home/Courses")]
		public IActionResult Courses()
		{
			//? Singleton's test
			UniversityContext u = UniversityContext.Instance;
			StudentRepository studentRepository = new StudentRepository(UniversityContext.Instance);
			return View(studentRepository.GetUniqueCourses().ToList());
		}
		[Route("Home/Search/{Course?}")]
		public IActionResult Search(string course)
		{
			StudentRepository studentRepository = new StudentRepository(UniversityContext.Instance);
			return View(studentRepository.GetStudentsByCourse(course).ToList());
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}