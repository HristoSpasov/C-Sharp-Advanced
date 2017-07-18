using System.Collections.Generic;

namespace _08.Military_Elite.Interfaces
{
    internal interface ILeutenantGeneral
    {
        IList<ISoldier> Privates { get; }
    }
}