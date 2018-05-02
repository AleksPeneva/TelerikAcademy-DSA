using System;
using System.Linq;

namespace ConnectAllCities
{
	class Program
    {
		private static int[,] initialCityConnections;

        static void Main(string[] args)
        {
			int numberOfTests = int.Parse(Console.ReadLine());
			for (int i = 0; i < numberOfTests; i++)
			{
				Test();
			}
        }

		private static void Test()
		{
			int minTransformations;
			int numberOfCities = int.Parse(Console.ReadLine());
			FillMatrix(numberOfCities);


			Console.WriteLine(minTransformations);
		}

		private static void FillMatrix(int numberOfCities)
		{
			for (int i = 0; i < numberOfCities; i++)
			{
				int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

				for (int j = 0; j < numberOfCities; j++)
				{
					initialCityConnections[i, j] = line[j];
				}
			}
		}
    }
}
