using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;
using System;
using System.IO;

namespace SimpleJudje.Judje
{
    public class Tester : IContentComparer
    {
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            try
            {
                OutputWriter.WriteMessageOnNewLine("Reading files...");
                string mismatchPath = this.GetMismatchPath(expectedOutputPath);

                // Read data rom files
                string[] userOutput = File.ReadAllLines(userOutputPath);
                string[] expectedOutput = File.ReadAllLines(expectedOutputPath);

                // Compare
                bool hasMismatch;
                string[] mismatches = this.GetLinesWithPossibleMismatches(userOutput, expectedOutput, out hasMismatch);

                // Print report
                this.PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (InvalidPathException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var mismatch in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(mismatch);
                }

                File.WriteAllLines(mismatchPath, mismatches);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
            }
        }

        private string[] GetLinesWithPossibleMismatches(string[] userOutput, string[] expectedOutput, out bool hasMismatch)
        {
            // Helper variables
            hasMismatch = false;
            string output = string.Empty;

            // Check if files have same length
            int minOutputLines = userOutput.Length;

            if (userOutput.Length != expectedOutput.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(userOutput.Length, expectedOutput.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            // Compare
            string[] mismatches = new string[userOutput.Length];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            for (int i = 0; i < minOutputLines; i++)
            {
                string currUserLine = userOutput[i];
                string currExpectedLine = expectedOutput[i];

                if (!currUserLine.Equals(currExpectedLine))
                {
                    output = string.Format("Mismatch at line {0} --" +
                                           "expected: \"{1}\", actual: \"{2}\"",
                        i, currUserLine, currExpectedLine);
                    output += Environment.NewLine;

                    hasMismatch = true;
                }
                else
                {
                    output = currUserLine;
                    output += Environment.NewLine;
                }

                mismatches[i] = output;
            }

            return mismatches;
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalMismatchPath = directoryPath + @"\Mismatches.txt";

            return finalMismatchPath;
        }
    }
}