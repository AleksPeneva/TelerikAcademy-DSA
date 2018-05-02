using System;
using System.Linq;

namespace ConnectAllCities
{
	class Program
	{
		private static int[,] initialCityConnections;
		private static int totalEdges = 0;
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
			if (GraphIsConnected())
			{
				minTransformations = 0;
			}
			else
			{
				if (totalEdges % 2 == 0)
				{
					minTransformations = -1;
				}
				else
				{
					minTransformations = 1;
				}
			}

			Console.WriteLine(minTransformations);
		}

		public static bool GraphIsConnected()
		{

			// For each node..
			for (int i = 0; i < initialCityConnections.GetLength(0); i++)
			{
				// Assume it's not connected unless shown otherwise.
				bool nodeIsConnected = false;

				// Check the column and row at the same time:
				for (int j = 0; j < initialCityConnections.GetLength(1); j++)
				{
					if (initialCityConnections[i, j] != 0 || initialCityConnections[j, i] != 0)
					{
						// It was non-zero; must have at least one connection.
						nodeIsConnected = true;
						break;
					}
					if (initialCityConnections[i, j] == 1)
					{
						totalEdges++;
					}
				}

				// Is the current node connected?
				if (!nodeIsConnected)
				{
					return false;
				}

			}
			totalEdges /= 2;
			// All ok otherwise:
			return true;
		}

		private static void FillMatrix(int numberOfCities)
		{
			initialCityConnections = new int[numberOfCities, numberOfCities];
			for (int i = 0; i < numberOfCities; i++)
			{
				string input = Console.ReadLine();
				int[] line = new int[input.Length];
				for (int k = 0; k < input.Length; k++)
				{
					line[i] = (int)Char.GetNumericValue(input[i]);
				}

				for (int j = 0; j < numberOfCities; j++)
				{
					initialCityConnections[i, j] = line[j];
				}
			}
		}
	}
}
