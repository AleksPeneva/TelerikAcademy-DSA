using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsOrder
{
	class Program
    {
		private static List<string> names;
		private static int studentsCnt;
		private static int changesCnt;
		private static LinkedList<string> students = new LinkedList<string>();
		private static Dictionary<string, LinkedListNode<string>> sittingArrangements;

		static void Main(string[] args)
        {
			List<int> inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
			studentsCnt = inputNumbers[0];
			changesCnt = inputNumbers[1];
			names = Console.ReadLine().Split().ToList();

			InitialSittingArrangement();
			ChangingArrangements();
			PrintOutput();
		}

		private static void PrintOutput()
		{
			Console.WriteLine(string.Join(" ", students));
		}

		private static void InitialSittingArrangement()
		{
			sittingArrangements = new Dictionary<string, LinkedListNode<string>>();

			for (int i = 0; i < studentsCnt; i++)
			{
				var student = new LinkedListNode<string>(names[i]);
				students.AddLast(student);
				sittingArrangements.Add(names[i], student);
			}
		}

		private static void ChangingArrangements()
		{
			for (int i = 0; i < changesCnt; i++)
			{
				List<string> input = Console.ReadLine().Split().ToList();
				string leftStudentName = input[0];
				string rightStudentName = input[1];

				LinkedListNode<string> leftStudent = sittingArrangements[leftStudentName];
				LinkedListNode<string> rightStudent = sittingArrangements[rightStudentName];

				students.Remove(leftStudent);
				students.AddBefore(rightStudent, sittingArrangements[leftStudentName]);
			}
		}
    }
}
