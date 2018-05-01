using System;
using System.Linq;

namespace Portals
{
	class Program
    {
		private static int[,] matrix;
		private static bool[,] visited;
		private static int maxMight;

		static void Main(string[] args)
        {
			int[] startPos = Console.ReadLine().Split().Select(int.Parse).ToArray();

			int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int rows = size[0];
			int cols = size[1];
			FillMatrix(rows, cols);

			int startRow = startPos[0];
			int startCol = startPos[0];
		}

		private static void FillMatrix(int rows, int cols)
		{
			matrix = new int[rows, cols];
			visited = new bool[rows, cols];
			for (int row = 0; row < rows; row++)
			{
				string[] curRow = Console.ReadLine().Split();

				for (int col = 0; col < cols; col++)
				{
					if (!int.TryParse(curRow[col], out matrix[row, col]))
					{
						matrix[row, col] = -1;
					}
				}
			}
		}

		private static void FindMaxMight(int row, int col)
		{
			int might = matrix[row, col];

		}

		private static bool ValidateCell(int row, int col)
		{
			bool isValid = (row > -1 && row < matrix.GetLength(0)) && (col > -1 && col < matrix.GetLength(1));
			return isValid;
		}
	}
}
