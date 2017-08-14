using _04.WorkForce.Core;
using _04.WorkForce.Entities;

namespace _04.WorkForce
{
    public class Program
    {
        public static void Main()
        {
            EmployeeCollection employeeCollection = new EmployeeCollection();
            JobCollection jobCollection = new JobCollection();

            Engine engine = new Engine(employeeCollection, jobCollection);
            engine.Run();
        }
    }
}