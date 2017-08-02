using System.Reflection;

namespace _02BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            // Make instance
            BlackBoxInt blackBox = (BlackBoxInt)Activator.CreateInstance(typeof(BlackBoxInt), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[0], null);

            // Process
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] cmdArgs = line.Split('_');

                Console.WriteLine(GetInnerValue(blackBox, cmdArgs));
            }
        }

        private static string GetInnerValue(BlackBoxInt blackBox, string[] cmdArgs)
        {
            // Find method
            MethodInfo methodInfo = typeof(BlackBoxInt).GetMethod(cmdArgs[0], BindingFlags.NonPublic | BindingFlags.Instance);

            // Invoke method
            methodInfo.Invoke(blackBox, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { int.Parse(cmdArgs[1]) }, null);

            // Get new int inner value
            return typeof(BlackBoxInt).GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(blackBox).ToString();
        }
    }
}