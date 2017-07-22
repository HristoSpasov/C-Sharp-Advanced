using System;

namespace _09.Custom_List_Sorter.Generic
{
    public static class Sorter
    {
        public static void Sort<T>(GenericList<T> list) where T : IComparable<T>
        {
            list.Sort();
        }
    }
}
