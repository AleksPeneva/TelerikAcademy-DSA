using System;
using System.Linq;

namespace GirlsGoneWild
{
    class Program
    {
        internal static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            var letters = Console.ReadLine().ToCharArray().OrderBy(l => l);
            int girls = int.Parse(Console.ReadLine());
        }
    }
}
