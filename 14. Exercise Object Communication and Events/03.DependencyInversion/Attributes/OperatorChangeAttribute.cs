using System;

namespace _03.DependencyInversion.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class OperatorChangeAttribute : Attribute
    {
        private char oper;

        public OperatorChangeAttribute(char oper)
        {
            this.oper = oper;
        }
    }
}