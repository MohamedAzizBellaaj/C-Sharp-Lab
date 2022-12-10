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
			UniversityContext u = UniversityContext.getInstance();
			List<Student> s = u.Student.ToList<Student>();
			foreach (Student student in s)
			{
				Console.WriteLine(student);
			}
			return View();
		}

		public IActionResult Privacy()
		{
			UniversityContext u = UniversityContext.getInstance();
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}