using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectAllCities
{
	class Program
	{
		private static int[,] initialCityConnections;
		private static int totalEdges = 0;
		private static StringBuilder output = new StringBuilder();
		static void Main(string[] args)
		{
			int numberOfTests = int.Parse(Console.ReadLine());
			for (int i = 0; i < numberOfTests; i++)
			{
				Test();
			}

			Console.Write(output);
		}

		private static void Test()
		{
			int minTransformations;
			int numberOfCities = int.Parse(Console.ReadLine());
			FillMatrix(numberOfCities);
			if (CountComponents(numberOfCities, initialCityConnections) == 1)
			{
				minTransformations = 0;
			}
			else
			{
				if (totalEdges < numberOfCities - 1)
				{
					minTransformations = -1;
				}
				else
				{
					minTransformations = 1;
				}
			}
			totalEdges = 0;
			output.AppendLine(minTransformations.ToString());
		}

		private static int CountComponents(int n, int[,] initialCityConnections)
		{
			int count = 0;
			var visited = new bool[n];
			var dict = new Dictionary<int, List<int>>();
			for (int i = 0; i < n; i++)
			{
				dict[i] = new List<int>();
			}

			for (int i = 0; i < initialCityConnections.GetLength(0); i++)
			{
				var from = initialCityConnections[i, 0];
				var to = initialCityConnections[i, 1];

				dict[from].Add(to);
				dict[to].Add(from);
			}

			for (int i = 0; i < n; i++)
			{
				if (!visited[i])
				{
					CountComponentsHelper(n, dict, i, visited);
					count++;
				}
			}

			return count;
		}
		private static void CountComponentsHelper(int n, Dictionary<int, List<int>> dict, int cur, bool[] visited)
		{
			if (visited[cur]) return;

			visited[cur] = true;

			foreach (var edge in dict[cur])
			{
				CountComponentsHelper(n, dict, edge, visited);
			}
		}

		private static void FillMatrix(int numberOfCities)
		{
			initialCityConnections = new int[numberOfCities, numberOfCities];
			for (int i = 0; i < numberOfCities; i++)
			{
				char[] input = Console.ReadLine().ToCharArray();

				for (int j = 0; j < numberOfCities; j++)
				{
					initialCityConnections[i, j] = Convert.ToInt32(input[j]) - 48;
					if (initialCityConnections[i, j] == 1)
					{
						totalEdges++;
					}
				}
			}
			totalEdges /= 2;
		}
	}
}
