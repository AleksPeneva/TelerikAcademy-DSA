using System;
using System.Collections.Generic;
using System.Linq;

namespace Passwords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            int length = int.Parse(input[0]);
            string relations = input[1];
            int k = int.Parse(input[2]);
            var output = new char[length];
            int[] typedDigits = new int[length];
            Hack(relations, length, k, 0, typedDigits, output);

            Console.WriteLine(output);
        }

        public static int Hack(string relations, int length, int k, int index, int[] typedDigits, char[] output)
        {
            if (length == 0)
            {
                return length;
            }

            if (index == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    typedDigits[0] = i;
                    length = Hack(relations, length, k, index + 1, typedDigits, output);
                }
                return length;
            }

            if (index == length)
            {
                if (k == 0)
                {
                    for (int i = 0; i < length; i++)
                    {
                        output[i] = (char)typedDigits[i];
                    }
                }
            }

            int digit;
            
            if (relations[index - 1] == '<')
            {
                digit = typedDigits[index - 1] == 0 ? 10 : typedDigits[index - 1];
                for (int i = 1; i < digit; i++)
                {
                    typedDigits[index - 1] = i;
                    length = Hack(relations, length, k, index, typedDigits, output);
                }

                return length;
            }

            if (relations[index - 1] == '>')
            {
                digit = typedDigits[index - 1];
                if (digit == 0)
                {
                    return length;
                }

                typedDigits[index] = 0;
                length = Hack(relations, length, k, index + 1, typedDigits, output);

                for (int i = digit + 1; i < 10; i++)
                {
                    typedDigits[index] = i;
                    length = Hack(relations, length, k, index + 1, typedDigits, output);
                }

                return length;
            }

            typedDigits[index] = typedDigits[index - 1];    // =
            return Hack(relations, length, k, index + 1, typedDigits, output);
        }
    }
}
