using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;

namespace WebApplicationTP3.Models
{
	public class Personal_info
	{
		public static List<Person> GetAllPerson(SQLiteConnection dbcon)
		{
			List<Person> personList = new List<Person>();
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
						Person person = new Person(id, first_name, last_name, email, image, country);
						personList.Add(person);
					}
				}
				return personList;
			}
		}
		public static Person? GetPerson(int id, SQLiteConnection dbcon)
		{
			Person? p;
			using (dbcon)
			{
				dbcon.Open();
				SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info WHERE id = @id", dbcon);
				cmd.Parameters.Add(new SQLiteParameter("@id", id));
				SQLiteDataReader reader = cmd.ExecuteReader();
				using (reader)
				{
					while (reader.Read())
					{
						string first_name = (string)reader["first_name"];
						string last_name = (string)reader["last_name"];
						string email = (string)reader["email"];
						string image = (string)reader["image"];
						string country = (string)reader["country"];
						p = new Person(id, first_name, last_name, email, image, country);
						return p;
					}
				}
			}
			return null;
		}

	}
}
