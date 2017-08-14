namespace _04.Recharge
{
    using _04.Recharge.Entities;

    public static class Program
    {
        public static void Main()
        {
            Employee employee = new Employee("123");
            Robot robot = new Robot("456", 10);

            employee.Work(10);
            employee.Sleep();

            robot.Work(5);
            robot.Recharge();
        }
    }
}