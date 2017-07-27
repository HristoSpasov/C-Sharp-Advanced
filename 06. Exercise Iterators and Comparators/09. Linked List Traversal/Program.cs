using System;

namespace _09.Linked_List_Traversal
{
    public class Program
    {
        public static void Main()
        {
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();

            int elementsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < elementsCount; i++)
            {
                string[] args = Console.ReadLine().Split();

                switch (args[0])
                {
                    case "Add":
                        myLinkedList.Add(int.Parse(args[1]));
                        break;

                    case "Remove":
                        myLinkedList.Remove(int.Parse(args[1]));
                        break;
                }
            }

            // Print result
            Console.WriteLine(myLinkedList.Count);
            Console.WriteLine(string.Join(" ", myLinkedList));
        }
    }
}