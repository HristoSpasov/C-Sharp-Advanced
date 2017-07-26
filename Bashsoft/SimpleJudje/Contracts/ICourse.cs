using System.Collections.Generic;

namespace SimpleJudje.Contracts
{
    public interface ICourse
    {
        string Name { get; }

        IReadOnlyDictionary<string, IStudent> StudentsByName { get; }

        void EnrollStudent(IStudent student);
    }
}