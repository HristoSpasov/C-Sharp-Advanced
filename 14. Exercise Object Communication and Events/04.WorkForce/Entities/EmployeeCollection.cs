using System.Collections.Generic;
using System.Linq;
using _04.WorkForce.Entities.Emplyees;

namespace _04.WorkForce.Entities
{
    public class EmployeeCollection
    {
        private readonly IList<Employee> employees;

        public EmployeeCollection()
        {
            this.employees = new List<Employee>();
        }

        public void AddEmployee(Employee newEmployee)
        {
            this.employees.Add(newEmployee);
        }

        public Employee GetEmplyee(string name)
        {
            return this.employees.First(n => n.Name == name);
        }
    }
}