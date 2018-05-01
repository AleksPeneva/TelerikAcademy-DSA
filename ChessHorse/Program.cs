﻿using System;
using System.Collections.Generic;

namespace ChessHorse
{
	class Program
    {
		private static int[,] matrix;
		private static int rows;
		private static int cols;
		private static int startRow;
		private static int startCol;
		private static int[] outputCol;
		private static int filledOutputColCells = 0;

        static void Main(string[] args)
        {
			rows = int.Parse(Console.ReadLine());
			cols = int.Parse(Console.ReadLine());
			startRow = int.Parse(Console.ReadLine());
			startCol = int.Parse(Console.ReadLine());

			outputCol = new int[rows];
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
			Queue<int[]> cellsToTraverseFrom = new Queue<int[]>();
			cellsToTraverseFrom.Enqueue(
				new int[]
				{
					startRow, startCol
				});
			matrix[startRow, startCol] = 1; //just at start, dw

			while ((cellsToTraverseFrom.Count != 0) && ())
			{
				int[] cell = cellsToTraverseFrom.Dequeue();

				if (cell[0] == cols/2)
				{
					filledOutputColCells++;
					outputCol[0] = matrix[0, 1];
				}
			}
		}
	}
}
