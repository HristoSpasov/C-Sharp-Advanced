namespace _07.Food_Shortage.Interfaces
{
    public interface IBuyer
    {
        string Name { get; }
        string Age { get; }
        int TotalFood { get; }

        void BuyFood();
    }
}