using System.Collections.Generic;

namespace _08.Military_Elite.Interfaces
{
    public interface IEngineer
    {
        List<IRepair> Repairs { get; }
    }
}