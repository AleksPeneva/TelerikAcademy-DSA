using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace SupermarketQueue
{
    public class Program
    {
        private static StringBuilder output = new StringBuilder();
        private static Bag<string> customers = new Bag<string>();
        private static BigList<string> queue = new BigList<string>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                List<string> command = input.Split().ToList();
                int position;
                string name;
                int count;
                switch (command[0])
                {
                    case "Append":
                        name = command[1];
                        Append(name);
                        break;
                    case "Insert":
                        position = int.Parse(command[1]);
                        name = command[2];
                        Insert(position, name);
                        break;
                    case "Find":
                        name = command[1];
                        Find(name);
                        break;
                    case "Serve":
                        count = int.Parse(command[1]);
                        Serve(count);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.Write(output);
        }

        private static void Append(string name)
        {
            queue.Add(name);
            customers.Add(name);
            output.AppendLine("OK");
        }

        private static void Insert(int position, string name)
        {
            if (position < 0 || position > queue.Count)
            {
                output.AppendLine("Error");
                return;
            }

            queue.Insert(position, name);
            customers.Add(name);
            output.AppendLine("OK");
        }

        private static void Find(string name)
        {
            output.AppendLine(customers.NumberOfCopies(name).ToString());
        }

        private static void Serve(int count)
        {
            if (count > queue.Count)
            {
                output.AppendLine("Error");
                return;
            }

            var served = queue.GetRange(0, count);
            queue.RemoveRange(0, count);
            customers.RemoveMany(served);
            output.AppendLine(string.Join(" ", served));
        }
    }
}
