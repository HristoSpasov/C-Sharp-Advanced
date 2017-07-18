using _04.Telephony.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace _04.Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {
        }

        public string Browse(string site)
        {
            if (!Regex.IsMatch(site, @"^\D*$"))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            if (!Regex.IsMatch(number, @"^\d*$"))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }
    }
}