using System;

namespace _10.Custom_List_Iterator.Generic
{
    public static class Sorter
    {
        public static void Sort<T>(GenericList<T> list) where T : IComparable<T>
        {
            list.Sort();
        }
    }
}
