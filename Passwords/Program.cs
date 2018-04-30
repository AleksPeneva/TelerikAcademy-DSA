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
            int[] keyboard = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            Hack(relations, length, k, 0, keyboard);

            Console.WriteLine(output);
        }

        public static int Hack(string relations, int length, int k, int index, int[] keyboard)
        {
            if (relations[index] == '<')
            {
                index = keyboard[index] == 0 ? 10 : keyboard[index];
                for (int i = 0; i < length; i++)
                {
                    keyboard[index] = i;
                    length = Hack(relations, length, k, index, keyboard);
                }

                return length;
            }

            if (relations[index] == '>')
            {
                index = keyboard[index];
                if (index == 0)
                {
                    return length;
                }

                keyboard[index] = 0;
                length = Hack(relations, length, k, index + 1, keyboard);

                for (int i = index + 1; i < length; i++)
                {
                    keyboard[index] = i;
                    length = Hack(relations, length, k, index + 1, keyboard);
                }

                return length;
            }
            
            return Hack(relations, length, k, index + 1, keyboard);
        }
    }
}
