using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using WebApplicationTP3.Models;
using static System.Net.Mime.MediaTypeNames;

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
			// *Select every person using sql command:
			using (dbcon)
			{
				dbcon.Open();
				SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", dbcon);
				SQLiteDataReader reader = cmd.ExecuteReader();
				using (reader)
				{
					while (reader.Read())
					{
						int id = (int)reader["id"];
						string first_name = (string)reader["first_name"];
						string last_name = (string)reader["last_name"];
						string email = (string)reader["email"];
						string image = (string)reader["image"];
						string country = (string)reader["country"];
						//DateTime date_birth = (DateTime)reader["date_birth"];
						Debug.WriteLine($"id : {id}, first_name : {first_name}, last_name : {last_name}, email : {email}, image : {image}, country : {country}");
					}
				}
			}
			//// *Select every person using GetAllPerson:
			//foreach (Person p in Personal_info.GetAllPerson(dbcon))
			//{
			//	Console.WriteLine(p);
			//}
			////*Select person with corresponding id using GetPerson
			//Person? p = Personal_info.GetPerson(5, dbcon);
			//if (p is not null)
			//{
			//	Console.WriteLine(p);
			//}
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