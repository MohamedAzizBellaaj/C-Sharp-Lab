namespace WebApplicationTP3.Models
{
	public class Person
	{
		public int? id { get; set; }
		public string? first_name { get; set; }
		public string? last_name { get; set; }
		public string? email { get; set; }
		public string? image { get; set; }
		public string? country { get; set; }
		public DateTime date_birth { get; set; } = new DateTime(2001, 1, 1, 0, 0, 0);
		public Person() { }
		public Person(int id, string first_name, string last_name, string email, string image, string country)
		{
			this.id = id;
			this.first_name = first_name;
			this.last_name = last_name;
			this.email = email;
			this.image = image;
			this.country = country;
		}
		override
		public string ToString()
		{
			return $"id : {id}, first_name : {first_name}, last_name : {last_name}, email : {email}, date_birth : {date_birth}, image : {image}, country : {country}";
		}
	}

}
