namespace _05.Security_Door.Entities
{
    using System;
    using _05.Security_Door.Contracts;

    public class KeyCardCheck : IRequestKeyCard
    {
        public KeyCardCheck()
        {
        }

        private bool IsValid(string code)
        {
            return true;
        }

        public bool ValidateUser()
        {
            string code = this.RequestKeyCard();
            if (this.IsValid(code))
            {
                return true;
            }

            return false;
        }

        public string RequestKeyCard()
        {
            Console.WriteLine("Slide your key card");
            return Console.ReadLine();
        }
    }
}