namespace SimpleJudje.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using SimpleJudje.Contracts;

    public class RepositorySorter : IDataSorter
    {
        public void OrderAndTake(Dictionary<string, double> studentWithMarks, string comparison, int studentsToTake)
        {
            switch (comparison.ToLower())
            {
                case "ascending":
                    this.PrintStudents(studentWithMarks.OrderBy(s => s.Value)
                        .Take(studentsToTake)
                        .ToDictionary(p => p.Key, p => p.Value));
                    break;

                case "descending":
                    this.PrintStudents(studentWithMarks.OrderByDescending(s => s.Value)
                        .Take(studentsToTake)
                        .ToDictionary(p => p.Key, p => p.Value));
                    break;

                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
                    break;
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (var kvp in studentsSorted)
            {
                OutputWriter.PrintStudent(kvp);
            }
        }
    }
}