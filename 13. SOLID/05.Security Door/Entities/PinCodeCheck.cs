namespace _05.Security_Door.Entities
{
    using System;
    using _05.Security_Door.Contracts;

    public class PinCodeCheck : IRequestPinCode
    {
        public PinCodeCheck()
        {
        }

        private bool IsValid(int pin)
        {
            return true;
        }

        public bool ValidateUser()
        {
            int pin = this.RequestPinCode();
            if (this.IsValid(pin))
            {
                return true;
            }

            return false;
        }

        public int RequestPinCode()
        {
            Console.WriteLine("Enter your pin code:");
            return int.Parse(Console.ReadLine());
        }
    }
}