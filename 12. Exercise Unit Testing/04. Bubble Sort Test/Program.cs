using System;

namespace _04.Bubble_Sort_Test
{
    public class Program
    {
        public static void Main()
        {
            int[] toSort = new int[] { 5, 4, 5, 94, 1 };

            BubbleSort<int> bubble = new BubbleSort<int>(toSort);

            int[] sorted = bubble.Sort();

            Console.WriteLine(string.Join(" ", toSort));
        }
    }
}