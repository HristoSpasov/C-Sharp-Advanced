using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private List<T> list;

    public Box()
    {
        this.list = new List<T>();
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }

    public T Remove()
    {
        T toReturn = this.list.Last();
        this.list.RemoveAt(this.list.Count - 1);
        return toReturn;
    }

    public int Count => this.list.Count;
}