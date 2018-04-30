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
            int[] typedDigits = new int[length];
            Hack(relations, length, k, 0, typedDigits);

            Console.WriteLine(output);
        }

        public static int Hack(string relations, int length, int k, int index, int[] typedDigits)
        {
            int digit;

            if (relations[index] == '=')
            {

            }

            if (relations[index] == '<')
            {
                digit = typedDigits[index] == 0 ? 10 : typedDigits[index];
                for (int i = 0; i < length; i++)
                {
                    typedDigits[index] = i;
                    length = Hack(relations, length, k, index, typedDigits);
                }

                return length;
            }

            if (relations[index] == '>')
            {
                digit = typedDigits[index];
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
