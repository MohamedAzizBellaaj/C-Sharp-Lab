using System.Collections;

namespace exoLambaExpressions
{
	public static partial class Extensions
	{
		public static ArrayList filtre(this ArrayList a, Func<int, bool> func)
		{
			ArrayList ret = new ArrayList();
			foreach (int x in a)
			{
				if (func(x))
				{
					ret.Add(x);
				}
			}
			return ret;
		}
	}
	internal class Program
	{
		static void affiche(ArrayList a)
		{
			foreach (int x in a)
			{
				Console.Write(x);
				Console.Write(" ");
			}
			Console.WriteLine();
		}
		static ArrayList filtre(ArrayList a, Func<int, bool> func)
		{
			ArrayList ret = new ArrayList();
			foreach (int x in a)
			{
				if (func(x))
				{
					ret.Add(x);
				}
			}
			return ret;
		}
		static void Main(string[] args)
		{
			ArrayList desInts = new ArrayList(); for (int i = 1; i <= 100; i++)
			{
				desInts.Add(i);
			}
			affiche(filtre(desInts, (a) => a % 9 == 0));
			affiche(desInts.filtre(a => a % 7 == 0));
		}
	}
}