using _05.Border_Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Border_Control.Core
{
    public class SocietyManager
    {
        private readonly List<IDable> societyMembers;

        public SocietyManager()
        {
            this.societyMembers = new List<IDable>();
        }

        public void AddMember(IDable newMember)
        {
            this.societyMembers.Add(newMember);
        }

        public string GetMembersWithIdEndingWith(string idEnd)
        {
            return string.Join(Environment.NewLine, this.societyMembers.Where(id => id.Id.EndsWith(idEnd)).Select(id => id.Id).ToList());
        }
    }
}