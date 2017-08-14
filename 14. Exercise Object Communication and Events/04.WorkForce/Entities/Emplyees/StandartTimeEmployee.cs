namespace _04.WorkForce.Entities.Emplyees
{
    public class StandartTimeEmployee : Employee
    {
        private const int DeafaultWorkingHoursPerWeek = 40;

        public StandartTimeEmployee(string name) : base(name, DeafaultWorkingHoursPerWeek)
        {
        }
    }
}