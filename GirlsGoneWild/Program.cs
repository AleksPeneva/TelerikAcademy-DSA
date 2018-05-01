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
        private static SortedSet<string> finalOutput = new SortedSet<string>();

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
                    List<char> newLetters = new List<char>(letterComb);
                    RepeatingPermutations(newLetters, 0, newLetters.Count, action =>
                    {
                        Combine(action, numComb);
                    });
                }
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine(finalOutput.Count.ToString());
            foreach (var item in finalOutput)
            {
                result.AppendLine(item);
            }

            Console.WriteLine(result.ToString().Trim());
        }

        internal static void Combine(List<char> letters, List<int> numbers)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < letters.Count; i++) 
            {     
                output.Append(numbers[i]);
                output.Append(letters[i]);
                output.Append('-');
            }
            output.Length--;
            finalOutput.Add(output.ToString());
        }

        internal static void Combinations(int[] arr, int start, int index, Action<int[]> action)
        {
            if (index >= numberOfGirls)
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
                var first = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = first;
            }
        }
    }
}
