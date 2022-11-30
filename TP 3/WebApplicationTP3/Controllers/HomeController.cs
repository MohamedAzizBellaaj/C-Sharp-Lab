using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using WebApplicationTP3.Models;

namespace WebApplicationTP3.Controllers
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
			SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
			using (dbcon)
			{
				dbcon.Open();
				SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", dbcon);
				SQLiteDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int id = (int)reader["id"];
					string first_name = (string)reader["first_name"];
					string last_name = (string)reader["last_name"];
					string email = (string)reader["email"];
					//DateTime date_birth = (DateTime)reader["date_birth"];
					string image = (string)reader["image"];
					string country = (string)reader["country"];
					Debug.WriteLine($"id : {id}, first_name : {first_name}, last_name : {last_name}, email : {email}, image : {image}, country : {country}");
				}
			}
			return View();
		}

		public IActionResult Privacy()
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