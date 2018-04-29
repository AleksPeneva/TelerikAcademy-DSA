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
                switch (command[0])
                {
                    case "Append":
                        
                        break;
                    case "Insert":

                        break;
                    case "Find":
                        
                        break;
                    case "Serve":

                        break;
                    case "End":
                        break;
                    default:
                        break;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(output);
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
            int count = 0;
            foreach (var customer in customers)
            {
                if (customer == name)
                {
                    count++;
                }
            }
            output.AppendLine(count.ToString());
        }

        private static void Serve(int count)
        {
            if (count > queue.Count)
            {
                output.AppendLine("Error");
                return;
            }

            var served = queue.Take(count);
            queue.RemoveRange(0, count);
            customers.RemoveMany(served);
            output.AppendLine(string.Join(" ", served));
        }
    }
}
