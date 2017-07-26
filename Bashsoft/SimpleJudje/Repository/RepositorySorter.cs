using SimpleJudje.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SimpleJudje.Repository
{
    public class RepositorySorter : IDataSorter
    {
        public void OrderAndTake(Dictionary<string, double> studentWithMarks,
            string comparison, int studentsToTake)
        {
            switch (comparison.ToLower())
            {
                case "ascending":
                    //OrderAndTake(wantedData, CompareInOrder, studentsToTake);
                    this.PrintStudents(studentWithMarks.OrderBy(s => s.Value)
                        .Take(studentsToTake)
                        .ToDictionary(p => p.Key, p => p.Value));
                    break;

                case "descending":
                    //OrderAndTake(wantedData, CompareInDescendingOrder, studentsToTake);
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

        //private static void OrderAndTake(Dictionary<string, List<int>> wantedData,
        //    Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc, int studentsToTake)
        //{
        //    var sortedStudents = GetSortedStudents(wantedData, studentsToTake, comparisonFunc);

        //    foreach (var student in sortedStudents)
        //    {
        //        OutputWriter.PrintStudent(student);
        //    }
        //}

        //private static Dictionary<string, List<int>> GetSortedStudents(Dictionary<string, List<int>> studentsWanted,
        //    int takeCount, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparison)
        //{
        //    int valuesTaken = 0;
        //    Dictionary<string, List<int>> studentsSorted = new Dictionary<string, List<int>>();
        //    KeyValuePair<string, List<int>> nextInOrder = new KeyValuePair<string, List<int>>();
        //    bool isSorted = false;

        //    while (true)
        //    {
        //        if (valuesTaken == takeCount)
        //        {
        //            break;
        //        }

        //        isSorted = true;

        //        foreach (var studentsWithScore in studentsWanted)
        //        {
        //            if (!string.IsNullOrEmpty(nextInOrder.Key))
        //            {
        //                int comparisonResult = comparison(studentsWithScore, nextInOrder);
        //                if (comparisonResult >= 0 && !studentsSorted.ContainsKey(studentsWithScore.Key))
        //                {
        //                    nextInOrder = studentsWithScore;
        //                    isSorted = false;
        //                }
        //            }
        //            else
        //            {
        //                if (!studentsSorted.ContainsKey(studentsWithScore.Key))
        //                {
        //                    nextInOrder = studentsWithScore;
        //                    isSorted = false;
        //                }
        //            }
        //        }

        //        if (!isSorted)
        //        {
        //            studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
        //            valuesTaken++;
        //            nextInOrder = new KeyValuePair<string, List<int>>();
        //        }
        //    }

        //    return studentsSorted;
        //}

        //private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue,
        //    KeyValuePair<string, List<int>> secondValue)
        //{
        //    return secondValue.Value.Sum().CompareTo(firstValue.Value.Sum());
        //}

        //private static int CompareInDescendingOrder(KeyValuePair<string, List<int>> firstValue,
        //    KeyValuePair<string, List<int>> secondValue)
        //{
        //    return firstValue.Value.Sum().CompareTo(secondValue.Value.Sum());
        //}
    }
}