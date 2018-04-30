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
            int[] typedDigits = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            Hack(relations, length, k, 0, typedDigits);

            Console.WriteLine(output);
        }

        public static int Hack(string relations, int length, int k, int index, int[] typedDigits)
        {
            if (relations[index] == '=')
            {

            }

            if (relations[index] == '<')
            {
                index = typedDigits[index] == 0 ? 10 : typedDigits[index];
                for (int i = 0; i < length; i++)
                {
                    typedDigits[index] = i;
                    length = Hack(relations, length, k, index, typedDigits);
                }

                return length;
            }

            if (relations[index] == '>')
            {
                index = typedDigits[index];
                if (index == 0)
                {
                    return length;
                }

                typedDigits[index] = 0;
                length = Hack(relations, length, k, index + 1, typedDigits);

                for (int i = index + 1; i < length; i++)
                {
                    typedDigits[index] = i;
                    length = Hack(relations, length, k, index + 1, typedDigits);
                }

                return length;
            }
            
            return Hack(relations, length, k, index + 1, typedDigits);
        }
    }
}
