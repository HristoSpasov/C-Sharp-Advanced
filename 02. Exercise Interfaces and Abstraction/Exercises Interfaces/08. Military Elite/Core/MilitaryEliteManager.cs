using _08.Military_Elite.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _08.Military_Elite.Core
{
    public class MilitaryEliteManager
    {
        private List<ISoldier> soldiers;

        public MilitaryEliteManager()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void AddSoldier(ISoldier newSoldier)
        {
            this.soldiers.Add(newSoldier);
        }

        public ISoldier GetSoldier(string idSearch)
        {
            return this.soldiers.FirstOrDefault(id => id.Id == idSearch);
        }

        public IReadOnlyCollection<ISoldier> Soldiers => this.soldiers.AsReadOnly();
    }
}