using _06.Birthday_Celebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Border_Control.Core
{
    public class SocietyManager
    {
        private readonly List<IBirthable> societyMembers;

        public SocietyManager()
        {
            this.societyMembers = new List<IBirthable>();
        }

        public void AddMember(IBirthable newMember)
        {
            this.societyMembers.Add(newMember);
        }

        public string GetMembersWithBirthYear(string birthYear)
        {
            List<string> matchingBirthYears = this.societyMembers.Where(bd => bd.Birthday.EndsWith(birthYear))
                .Select(y => y.Birthday).ToList();

            return string.Join(Environment.NewLine, matchingBirthYears);
        }
    }
}