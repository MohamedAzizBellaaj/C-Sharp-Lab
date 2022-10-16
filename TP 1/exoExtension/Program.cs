namespace exoExtension
{
	public static partial class Extensions
	{
		public static string RetireCar(this string s, char c)
		{
			return s.Remove(s.IndexOf(c), 1);
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			string s = "voiture";
			Console.WriteLine(s.RetireCar('t'));
		}
	}
}