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

		static void Main(string[] args)
		{
			numbers = int.Parse(Console.ReadLine());
			letters = Console.ReadLine().ToCharArray().OrderBy(l => l).ToArray();
			girlsCount = int.Parse(Console.ReadLine());
		}
	}
}
