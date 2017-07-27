using System;

namespace _09.Linked_List_Traversal.Exceptions
{
    public class EmptyCollectionException : Exception
    {
        private const string msg = "Empty collection";

        public EmptyCollectionException() : base(msg)
        {
        }
    }
}