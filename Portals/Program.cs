using System;
using System.Collections.Generic;
using System.Linq;

namespace Portals
{
	class Program
    {
		private static int[,] matrix;
		private static bool[,] visited;
		private static int maxMight;
		private static List<int> mights = new List<int>();

		static void Main(string[] args)
        {
			int[] startPos = Console.ReadLine().Split().Select(int.Parse).ToArray();

			int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int rows = size[0];
			int cols = size[1];
			FillMatrix(rows, cols);

			int startRow = startPos[0];
			int startCol = startPos[0];
			FindMaxMight(startRow, startCol);

			Console.WriteLine(maxMight);
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
					if (!int.TryParse(curRow[col], out matrix[row, col]))	// #
					{
						matrix[row, col] = -1;
					}
				}
			}
		}

		private static void FindMaxMight(int row, int col)
		{
			if (visited[row, col])
			{
				return;
			}

			int might = matrix[row, col];

			if (!AbleToTeleport(row, col, might))
			{
				return;
			}

			mights.Add(might);

			visited[row, col] = true;

			if (ValidateCell(row + might, col))
			{
				FindMaxMight(row + might, col);
			}
			if (ValidateCell(row - might, col))
			{
				FindMaxMight(row - might, col);
			}
			if (ValidateCell(row, col + might))
			{
				FindMaxMight(row, col + might);
			}
			if (ValidateCell(row, col - might))
			{
				FindMaxMight(row, col - might);
			}

			visited[row, col] = false;
			
			int mightsSum = mights.Sum();
			maxMight = maxMight > mightsSum ? maxMight : mightsSum;
		}

		private static bool ValidateCell(int row, int col)
		{
			bool isValid = (row > -1 && row < matrix.GetLength(0)) && (col > -1 && col < matrix.GetLength(1));
			return isValid;
		}

		private static bool AbleToTeleport(int row, int col, int might)
		{
			bool able = ValidateCell(row + might, col) &&
						(ValidateCell(row - might, col) && 
						ValidateCell(row, col + might) && 
						ValidateCell(row, col - might));

			return able;
		}
	}
}
