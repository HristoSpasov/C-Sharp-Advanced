using System.Collections.Generic;

namespace _08.Military_Elite.Interfaces
{
    public interface ICommando
    {
        List<IMission> Missions { get; }
    }
}