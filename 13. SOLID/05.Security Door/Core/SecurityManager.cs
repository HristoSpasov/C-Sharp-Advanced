namespace _05.Security_Door.Core
{
    using System;
    using _05.Security_Door.Contracts;

    public class SecurityManager
    {
        private readonly IRequestKeyCard keyCardCheck;
        private readonly IRequestPinCode pinCodeCheck;

        public SecurityManager(IRequestKeyCard keyCardCheck, IRequestPinCode pinCodeCheck)
        {
            this.keyCardCheck = keyCardCheck;
            this.pinCodeCheck = pinCodeCheck;
        }

        public void Check()
        {
            Console.WriteLine("Choose option: 1 - KeyCard, 2 - PinCode:");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine(this.keyCardCheck.ValidateUser());
                    break;

                case 2:
                    Console.WriteLine(this.pinCodeCheck.ValidateUser());
                    break;
            }
        }
    }
}