using _09.Traffic_Lights.Enums;
using System;
using System.Linq;

namespace _09.Traffic_Lights
{
    public class Program
    {
        public static void Main()
        {
            // Read input
            Light[] lights = Console.ReadLine()
                .Split()
                .Select(l => (Light)Enum.Parse(typeof(Light), l))
                .ToArray();

            int linesToProcess = int.Parse(Console.ReadLine());

            // Process
            for (int i = 0; i < linesToProcess; i++)
            {
                for (int j = 0; j < lights.Length; j++)
                {
                    int currLightId = ((int)lights[j] + 1) % 3;
                    lights[j] = (Light)currLightId;
                }

                Console.WriteLine(string.Join(" ", lights));
            }
        }
    }
}