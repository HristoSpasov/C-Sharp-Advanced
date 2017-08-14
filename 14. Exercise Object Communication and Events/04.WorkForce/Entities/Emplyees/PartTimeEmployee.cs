namespace _04.WorkForce.Entities.Emplyees
{
    public class PartTimeEmployee : Employee
    {
        private const int DeafaultWorkingHoursPerWeek = 20;

        public PartTimeEmployee(string name) : base(name, DeafaultWorkingHoursPerWeek)
        {
        }
    }
}