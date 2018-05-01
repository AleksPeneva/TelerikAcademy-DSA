using System;
using System.Collections.Generic;
using System.Linq;

namespace GirlsGoneWild
{
	class Program
	{
		private static int numbers;
		private static char[] letters;
		private static int girlsCount;
		private static string[] combo;
		private static Dictionary<char, int> letterRepetitions = new Dictionary<char, int>();

		static void Main(string[] args)
		{
			OrganizeData();
		}

		private static void OrganizeData()
		{
			numbers = int.Parse(Console.ReadLine());
			letters = Console.ReadLine().ToCharArray().OrderBy(l => l).ToArray();
			girlsCount = int.Parse(Console.ReadLine());
			combo = new string[girlsCount];
			foreach (var letter in letters)
			{
				if (!letterRepetitions.ContainsKey(letter))
				{
					letterRepetitions.Add(letter, 0);
				}
				letterRepetitions[letter]++;
			}
		}
	}
}
