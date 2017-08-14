namespace _01.Database.Utilities
{
    public class EmptyArrayGenerator<T>
    {
        public T[] CreateArray(int arraySize)
        {
            return new T[arraySize];
        }
    }
}