﻿using System;

namespace _06.Generic_Count_Method_Strings.Generics
{
    public class Box<T> where T : IComparable<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }

        public int CompareTo(T obj)
        {
            return this.Value.CompareTo(obj);
        }
    }
}