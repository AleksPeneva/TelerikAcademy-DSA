using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GirlsGoneWild
{
    class Program
    {
        private static int numberOfGirls;
        private static List<List<int>> combOfNumbers = new List<List<int>>();  // lists of number combinations
        private static List<List<char>> combOfLetters = new List<List<char>>();  // lists of letter combinations
        private static char[] letters;
        private static SortedSet<string> finalOutput;

        internal static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers =new int[n];
            letters = Console.ReadLine().ToCharArray().OrderBy(l => l).ToArray();
            numberOfGirls = int.Parse(Console.ReadLine());

            Combinations(numbers, 0, 0, comb =>
            {
                combOfNumbers.Add(new List<int>(comb));
            });
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

            foreach (var numComb in combOfNumbers)
            {
                foreach (var letterComb in combOfLetters)
                {
                    RepeatingPermutations(letterComb, 0, 0, action =>
                    {

                    });
                }
            }

            Console.Write(finalOutput);
        }

        internal static void Combine(List<char> letters, List<int> numbers)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < letters.Count; i++)
            {                
                for (int j = 0; j < numberOfGirls; j++)
                {
                    output.Append(numbers[j]);
                    output.Append(letters[i]);
                    output.Append("-");
                }

                finalOutput.Add(output.ToString().TrimEnd('-'));
                output.Clear();
            }
        }

        internal static void Combinations(int[] arr, int start, int index, Action<int[]> action)
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
        
        internal static void RepeatingPermutations(List<char> arr, int start, int n, Action<List<char>> action)
        {
            action(arr);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        char temp = arr[left];   //swap
                        arr[left] = arr[right];
                        arr[right] = temp;
                        
                        RepeatingPermutations(arr, left + 1, n, action);
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
