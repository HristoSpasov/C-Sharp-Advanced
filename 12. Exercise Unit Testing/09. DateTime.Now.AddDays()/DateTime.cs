namespace _09.DateTime.Now.AddDays__
{
    using _09.DateTime.Now.AddDays__.Contracts;

    public class DateTime : IDateTime
    {
        System.DateTime IDateTime.AddDays(int daysToAdd)
        {
            return System.DateTime.Now.AddDays(daysToAdd);
        }
    }
}
