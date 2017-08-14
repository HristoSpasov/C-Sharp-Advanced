namespace _05.Security_Door
{
    using _05.Security_Door.Contracts;
    using _05.Security_Door.Core;
    using _05.Security_Door.Entities;

    public class Program
    {
        public static void Main()
        {
            IRequestKeyCard keyCardCheck = new KeyCardCheck();
            IRequestPinCode pinCodeCheck = new PinCodeCheck();
            SecurityManager manager = new SecurityManager(keyCardCheck, pinCodeCheck);
            manager.Check();
        }
    }
}