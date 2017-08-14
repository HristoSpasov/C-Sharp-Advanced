namespace _02.Extended_Database.Utilities
{
    public class EmptyArrayGenerator<T>
    {
        public T[] CreateArray(int arraySize)
        {
            return new T[arraySize];
        }
    }
}