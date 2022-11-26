using System.Collections;

namespace exoGenerics
{
	public class Pile : IEnumerable
	{
		public delegate void WarningDelegate(int count);
		public event WarningDelegate Warning;
		public ArrayList Stack { get; }
		private int _size;
		public Pile(int size)
		{
			Stack = new ArrayList(size);
			_size = size;
		}
		public void empile<T>(T e)
		{
			if (Stack.Count < _size)
			{
				Stack.Insert(0, e);
			}
			if (Stack.Count >= _size)
			{
				Warning(Stack.Count);
			}
		}

		public void depile()
		{
			try
			{
				Stack.RemoveAt(0);
			}
			catch { }

		}
		public IEnumerator GetEnumerator()
		{
			foreach (var item in Stack)
			{
				yield return item;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	public class Personne
	{
		public Personne(string nom, int age)
		{ this.nom = nom; this.age = age; }
		public override string ToString()
		{
			return this.nom + " " + this.age.ToString();
		}
		private string nom;
		private int age;
	}
	public class Program
	{
		static void Main(string[] args)
		{
			Pile p = new Pile(4);
			p.Warning += WarningMessage;
			p.depile();
			p.empile(new Personne("toto", 12));
			p.empile(new Personne("titi", 15));
			p.empile(new Personne("tutu", 25));
			p.depile();
			p.empile(new Personne("toutou", 28));
			p.empile(new Personne("tintin", 14));
			p.empile(new Personne("tata", 11));
			foreach (Personne pe in p.Stack)

				Console.WriteLine(pe.ToString());
		}
		static void WarningMessage(int count)
		{
			Console.WriteLine($"nombre d'éléments :{count}\nattention pile pleine");
		}

	}
}