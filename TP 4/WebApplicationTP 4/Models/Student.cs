using System.ComponentModel.DataAnnotations;

namespace WebApplicationTP_4.Models
{
	public class Student
	{
		[Key]
		public int id { get; set; }
		public string? first_name { get; set; }
		public string? last_name { get; set; }
		public string? phone_number { get; set; }
		public string? university { get; set; }
		public string? timestamp { get; set; }
		public string? course { get; set; }

		override
		public string ToString()
		{
			return $"first_name : {first_name}, last_name : {last_name}, phone_number : {phone_number}, university : {university}, timestamp : {timestamp}, course : {course}";
		}
	}
}
