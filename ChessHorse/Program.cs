using System;

namespace ChessHorse
{
	class Program
    {
		private static int[,] matrix;
        static void Main(string[] args)
        {
			int rows = int.Parse(Console.ReadLine());
			int cols = int.Parse(Console.ReadLine());
			int startRow = int.Parse(Console.ReadLine());
			int startCol = int.Parse(Console.ReadLine());

			int[] outputCol = new int[rows];
			matrix = new int[rows, cols];

			BFS();

			PrintOutput(outputCol);
		}

		private static void PrintOutput(int[] outputCol)
		{
			for (int i = 0; i < outputCol.Length; i++)
			{
				Console.WriteLine(outputCol[i]);
			}
		}

		private static void BFS()
		{
			throw new NotImplementedException();
		}
	}
}
