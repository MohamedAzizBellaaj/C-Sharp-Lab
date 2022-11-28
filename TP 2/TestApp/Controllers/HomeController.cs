using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Models;

namespace TestApp.Controllers
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
			return View();
		}

		public IActionResult Privacy(int id)
		{
			UserModel u = new UserModel
			{
				Id = id,
				Name = "Mohamed Aziz Bellaaj",
				Email = "azizbellaaj9@yahoo.fr"
			};
			return View(u);
		}
		public IActionResult About()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}