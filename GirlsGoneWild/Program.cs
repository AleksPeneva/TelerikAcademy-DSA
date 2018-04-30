using System;
using System.Collections.Generic;
using System.Linq;

namespace GirlsGoneWild
{
    class Program
    {
        private static int numberOfGirls;
        private List<List<int>> combOfNumbers = new List<List<int>>();  // lists of combinations
        internal static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers =new int[n];
            var letters = Console.ReadLine().ToCharArray().OrderBy(l => l);
            numberOfGirls = int.Parse(Console.ReadLine());

            Combinations(numbers, 0, 0);
        }

        internal static void Combinations(int[] arr, int start, int index)
        {
            if (index > numberOfGirls)
            {

            }
            else
            {
                for (int i = start; i < arr.Length; i++)
                {
                    arr[index] = i;
                    Combinations(arr, index+1, i+1);
                }
            }

        }
    }
}
