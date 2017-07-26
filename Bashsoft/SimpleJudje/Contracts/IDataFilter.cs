using System.Collections.Generic;

namespace SimpleJudje.Contracts
{
    public interface IDataFilter
    {
        void FilterAndTake(Dictionary<string, double> studentWithMarks, string wantedFilter, int studentsToTake);
    }
}