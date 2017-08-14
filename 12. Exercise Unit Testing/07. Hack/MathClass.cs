using System;

namespace _07.Hack
{
    public class MathClass : IMath
    { 
        public double GetmathAbs(double operand)
        {
            return Math.Abs(operand);
        }

        public double GetMathFloor(double operand)
        {
            return Math.Floor(operand);
        }
    }
}
