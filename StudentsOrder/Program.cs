using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsOrder
{
    class Program
    {
		private static List<string> names;
		private static int studentsCnt;
		private static int changesCnt;
		private static Dictionary<string, LinkedListNode<string>> sittingArrangement;

		static void Main(string[] args)
        {
			List<int> inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
			studentsCnt = inputNumbers[0];
			changesCnt = inputNumbers[1];
			names = Console.ReadLine().Split().ToList();

			InitialSittingArrangement();

		}

		private static void InitialSittingArrangement()
		{
			sittingArrangement = new Dictionary<string, LinkedListNode<string>>();

			for (int i = 0; i < studentsCnt; i++)
			{
				var arrangement = new LinkedListNode<string>(names[i]);
			}
		}
    }
}
