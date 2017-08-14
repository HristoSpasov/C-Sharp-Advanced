using System;

namespace _04.WorkForce.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CommandAttribute : Attribute
    {
    }
}