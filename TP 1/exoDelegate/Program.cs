using System;
using System.Collections.Generic;
using System.Text;
namespace exoDelegate
{
	class Calcul
	{
		public delegate int delegateCalcul(int a, int b);
		public static int somme(int a, int b)
		{
			return a + b;
		}
		public static int produit(int a, int b)
		{
			return a * b;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			string[] inputs = Console.ReadLine().Split();
			int a = int.Parse(inputs[0]);
			int b = int.Parse(inputs[1]);
			char op = char.Parse(inputs[2]);
			Calcul.delegateCalcul? func;
			switch (op)
			{
				case '+':
					func = Calcul.somme;
					break;
				case '*':
					func = Calcul.produit;
					break;
				default:
					func = null;
					break;
			}
			Console.WriteLine(func is not null ? $"{a} {op} {b} = {func.Invoke(a, b)}" : "Invalid operator");
		}
	}
}