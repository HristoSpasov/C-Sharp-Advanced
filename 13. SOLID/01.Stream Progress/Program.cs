namespace _01.Stream_Progress
{
    using System;
    using _01.Stream_Progress.Contracts;

    public class Program
    {
        public static void Main()
        {
            IStream fileStream = new File("Doc", 1024, 40);
            IStream musiStream = new Music("Pink Floyd", "The final cut", 40, 500);

            Console.WriteLine(fileStream);
            Console.WriteLine(musiStream);
        }
    }
}