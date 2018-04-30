using System;
using System.Collections.Generic;
using System.Linq;

namespace GirlsGoneWild
{
    class Program
    {
        private static int numberOfGirls;
        private static List<List<int>> combOfNumbers = new List<List<int>>();  // lists of number combinations
        private static List<List<char>> combOfLetters = new List<List<char>>();  // lists of letter combinations
        private static char[] letters;

        internal static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers =new int[n];
            letters = Console.ReadLine().ToCharArray().OrderBy(l => l).ToArray();
            numberOfGirls = int.Parse(Console.ReadLine());

            Combinations(numbers, 0, 0);
            numbers = new int[letters.Length];
            Combinations(numbers, 0, 0);
        }

        private static void AddNumberCombinations(int[] arr)
        {
            foreach (var item in arr)
            {
                combOfNumbers.Add(new List<int>(item));
            }
        }

        private static void AddLetterCombinations(int[] arr)
        {
            List<char> curCombination = new List<char>();
            for (int i = 0; i < arr.Length; i++)
            {
                curCombination.Add(letters[arr[i]]);
            }
            combOfLetters.Add(curCombination);
        }

        internal static void Combinations(int[] arr, int start, int index)
        {
            if (index > numberOfGirls)
            {
                AddNumberCombinations(arr);
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
