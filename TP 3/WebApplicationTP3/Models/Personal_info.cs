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
					return personList;
				}
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
		public static void Add(Person person, SQLiteConnection dbcon)
		{
			using (dbcon)
			{
				dbcon.Open();
				SQLiteCommand cmd = new SQLiteCommand("INSERT INTO personal_info VALUES (@id, @first_name, @last_name, @email, @date_birth, @image, @country)", dbcon);
				cmd.Parameters.Add(new SQLiteParameter("@id", person.id));
				cmd.Parameters.Add(new SQLiteParameter("@first_name", person.first_name));
				cmd.Parameters.Add(new SQLiteParameter("@last_name", person.last_name));
				cmd.Parameters.Add(new SQLiteParameter("@email", person.email));
				cmd.Parameters.Add(new SQLiteParameter("@date_birth", person.date_birth));
				cmd.Parameters.Add(new SQLiteParameter("@image", person.image));
				cmd.Parameters.Add(new SQLiteParameter("@country", person.country));
				cmd.ExecuteNonQuery();
			}
		}
		public static int Search(string first_name, string country, SQLiteConnection dbcon)
		{
			using (dbcon)
			{
				dbcon.Open();
				SQLiteCommand cmd = new SQLiteCommand("SELECT id FROM personal_info WHERE first_name = @first_name AND country = @country",dbcon);
				cmd.Parameters.Add(new SQLiteParameter("@first_name", first_name));
				cmd.Parameters.Add(new SQLiteParameter("@country",country));
				return (int)cmd.ExecuteScalar();
			}
		}
	}
}
