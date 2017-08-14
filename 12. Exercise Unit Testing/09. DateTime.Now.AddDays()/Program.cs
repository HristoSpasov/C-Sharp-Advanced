namespace _09.DateTime.Now.AddDays__
{
    using System;
    using _09.DateTime.Now.AddDays__.Contracts;

    public class Program
    {
        public static void Main()
        {
            IDateTime data = new DateTime();
            Console.WriteLine(data.AddDays(-1));
        }
    }
}
