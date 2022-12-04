using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using WebApplicationTP3.Models;

namespace WebApplicationTP3.Controllers
{
	public class PersonController : Controller
	{
		[Route("/Person")]
		[Route("Person/All")]
		public IActionResult All()
		{
			SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
			return View(Personal_info.GetAllPerson(dbcon));
		}
		[Route("Person/{id?}")]
		public IActionResult GetById(int id)
		{
			SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
			return View(Personal_info.GetPerson(id, dbcon));
		}
		[Route("Person/Add")]
		[HttpPost]
		public RedirectToActionResult Add(Person p)
		{
			SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
			Personal_info.Add(p, dbcon);
			return RedirectToAction("GetById", new { id = p.id });
		}
		[Route("Person/Add")]
		public IActionResult Add()
		{
			return View();
		}
		[Route("Person/Search")]
		[HttpPost]
		public RedirectToActionResult Search(Person p)
		{
			SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
			return RedirectToAction("GetById", new { id = Personal_info.Search(p.first_name, p.country, dbcon) });
		}
		[Route("Person/Search")]
		public IActionResult Search()
		{
			return View();
		}
	}
}
