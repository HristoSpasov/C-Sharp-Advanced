namespace _04.WorkForce.Entities.Emplyees
{
    public abstract class Employee
    {
        protected Employee(string name, int workingHoursPerWeek)
        {
            this.Name = name;
            this.WorkingHoursPerWeek = workingHoursPerWeek;
        }

        public string Name { get; private set; }

        public int WorkingHoursPerWeek { get; private set; }
    }
}