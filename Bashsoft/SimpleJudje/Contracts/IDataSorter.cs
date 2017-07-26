using System.Collections.Generic;

namespace SimpleJudje.Contracts
{
    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> studentWithMarks,
            string comparison, int studentsToTake);
    }
}