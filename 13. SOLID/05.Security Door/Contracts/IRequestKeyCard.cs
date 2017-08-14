namespace _05.Security_Door.Contracts
{
    public interface IRequestKeyCard : ISecurityCheck
    {
        string RequestKeyCard();
    }
}