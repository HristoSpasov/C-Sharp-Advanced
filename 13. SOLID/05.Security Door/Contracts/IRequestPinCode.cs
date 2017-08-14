namespace _05.Security_Door.Contracts
{
    public interface IRequestPinCode : ISecurityCheck
    {
        int RequestPinCode();
    }
}