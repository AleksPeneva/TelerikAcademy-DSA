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
        private static SortedSet<string> output;

        internal static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers =new int[n];
            letters = Console.ReadLine().ToCharArray().OrderBy(l => l).ToArray();
            numberOfGirls = int.Parse(Console.ReadLine());

            Combinations(numbers, 0, 0, comb => combOfNumbers.Add(new List<int>(comb)));
            numbers = new int[letters.Length];
            Combinations(numbers, 0, 0, comb =>
            {
                List<char> curCombination = new List<char>();
                for (int i = 0; i < numberOfGirls; i++)
                {
                    curCombination.Add(letters[comb[i]]);
                }
                combOfLetters.Add(curCombination);
            });
        }

        //private static void AddNumberCombinations(int[] arr)
        //{
        //    foreach (var item in arr)
        //    {
        //        combOfNumbers.Add(new List<int>(item));
        //    }
        //}

        //private static void AddLetterCombinations(int[] arr)
        //{
        //    List<char> curCombination = new List<char>();
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        curCombination.Add(letters[arr[i]]);
        //    }
        //    combOfLetters.Add(curCombination);
        //}

        internal static void /*Number*/Combinations(int[] arr, int start, int index, Action<int[]> action)
        {
            if (index > numberOfGirls)
            {
                action(arr);
            }
            else
            {
                for (int i = start; i < arr.Length; i++)
                {
                    arr[index] = i;
                    Combinations(arr, index+1, i+1, action);
                }
            }
        }

        //internal static void LetterCombinations(int[] arr, int start, int index)
        //{
        //    if (index > numberOfGirls)
        //    {
        //        AddLetterCombinations(arr);
        //    }
        //    else
        //    {
        //        for (int i = start; i < numberOfGirls; i++)
        //        {
        //            arr[index] = i;
        //            LetterCombinations(arr, index + 1, i + 1);
        //        }
        //    }
        //}

        internal static void RepeatingPermutations(int[] arr, int start, int n)         // letters, not numbers
        {
            

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        int temp = arr[left];   //swap
                        arr[left] = arr[right];
                        arr[right] = temp;
                        
                        RepeatingPermutations(arr, left + 1, n);
                    }
                }
                int first = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = first;
            }
        }
    }
}
