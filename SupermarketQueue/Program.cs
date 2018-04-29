using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();
            SingleLinkedList queue = new SingleLinkedList();
            string input = Console.ReadLine();
            while (input != "End")
            {
                List<string> command = input.Split().ToList();
                switch (command[0])
                {
                    case "Append":
                        InsertTail(queue, command[1], output);
                        break;
                    case "Insert":
                        int position = int.Parse(command[1]);
                        Insert(position, command[2], queue, output);
                        break;
                    case "Find":
                        Find(command[1], queue, output);
                        break;
                    case "Serve":
                        int count = int.Parse(command[1]);
                        Serve(count, queue, output);
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

        internal static void Serve(int count, SingleLinkedList queue, StringBuilder output)
        {

        }

        internal static void Find(string name, SingleLinkedList queue, StringBuilder output)
        {

        }

        internal static void Insert(int position, string name, SingleLinkedList queue, StringBuilder output)
        {
            if (position == 0)
            {
                InsertHead(position, name, queue, output);
            }
            else
            {

            }
        }

        internal static void InsertHead(int position, string name, SingleLinkedList queue, StringBuilder output)
        {
            Node newNode = new Node(name)
            {
                Next = queue.head
            };
            queue.head = newNode;
            Console.WriteLine("OK");
        }

        internal static void InsertTail(SingleLinkedList queue, string name, StringBuilder output)
        {
            Node newNode = new Node(name);
            if (queue.head == null)
            {
                queue.head = newNode;
                return;
            }
            Node tail = GetTail(queue);
            tail.Next = newNode;
        }

        internal static void InsertAt(int position, string name, SingleLinkedList list, StringBuilder output)
        {
            Node newNode = new Node(name)
            {
                Next = list.head
            };
            list.head = newNode;
            Console.WriteLine("OK");
        }

        internal static Node GetTail(SingleLinkedList queue)
        {
            Node temp = queue.head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }
    }

    internal class Node
    {
        private string name;
        public Node(string n)
        {
            this.name = n;
            this.Next = null;
        }

        public Node Next { get; set; }
    }

    internal class SingleLinkedList
    {
        internal Node head;
    }

}
