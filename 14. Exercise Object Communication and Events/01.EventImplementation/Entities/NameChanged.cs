using System;

namespace _01.EventImplementation.Entities
{
    public class NameChanged
    {
        public void OnNameChanged(object sourse, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}