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
		private static List<string> output = new List<string>();

		static void Main(string[] args)
		{
			OrganizeData();
			Permutations(0, 0);
			Console.WriteLine(output.Count());
			Console.WriteLine(string.Join(Environment.NewLine, output));
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

		private static void Permutations(int number, int elementsCount)
		{
			if (elementsCount == combo.Length)
			{
				string perm = string.Join("-", combo);
				if (output.Contains(perm))
				{
					output.Add(perm);
				}
				return;
			}

			for (int i = number; i < numbers; i++)
			{
				for (int j = 0; j < letters.Length; j++)
				{
					if (letterRepetitions[letters[j]] == 0)
					{
						continue;
					}

					string permElement = $"{i}{letters[j]}";
					combo[elementsCount] = permElement;
					letterRepetitions[letters[j]]--;
					Permutations(j + 1, elementsCount + 1);
				}
			}
		}
	}
}
