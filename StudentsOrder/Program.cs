using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsOrder
{
    class Program
    {
        static void Main(string[] args)
        {
			List<int> inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
			int studentsCnt = inputNumbers[0];
			int changesCnt = inputNumbers[1];

			List<string> names = Console.ReadLine().Split().ToList();

			var seatingArrangement = new Dictionary<string, LinkedListNode<string>>();

        }
    }
}
