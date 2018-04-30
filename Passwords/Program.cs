using System;

namespace Passwords
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string relations = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());
            var output = new char[length];
            string keyboard = "1234567890";
            Hack(relations, length, k, 0, keyboard);

            Console.WriteLine(output);
        }

        public static int Hack(string relations, int length, int k, int index, string keyboard)
        {
            if (relations[index] == '<')
            {

            }

            if (relations[index] == '>')
            {

            }
        }
    }
}
