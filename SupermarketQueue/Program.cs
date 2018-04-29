using System;

namespace SupermarketQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        internal void Insert(int position, string name, SingleLinkedList queue)
        {
            if (position == 0)
            {
                InsertHead(position, name, queue);
            }
            else
            {

            }
        }

        internal void InsertHead(int position, string name, SingleLinkedList queue)
        {
            Node newNode = new Node(name)
            {
                Next = queue.head
            };
            queue.head = newNode;
            Console.WriteLine("OK");
        }

        internal void InsertTail(SingleLinkedList queue, string name)
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

        internal void InsertAt(int position, string name, SingleLinkedList list)
        {
            Node newNode = new Node(name)
            {
                Next = list.head
            };
            list.head = newNode;
            Console.WriteLine("OK");
        }

        internal Node GetTail(SingleLinkedList queue)
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
        private Node next;
        public Node(string n)
        {
            this.name = n;
            this.next = null;
        }

        public Node Next { get; set; }
    }

    internal class SingleLinkedList
    {
        internal Node head;
    }

}
