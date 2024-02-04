using System;

namespace stuff.Calculate
{
    public class AddOperation: Operation
    {
        public override double? Calculate(double num1, double num2)
        {
            return num1 + num2;
        }
    }
    public class SubtractOperation: Operation
    {
        public override double? Calculate(double num1, double num2)
        {
            return num1 - num2;
        }
    }
    public class MultiplyOperation: Operation
    {
        public override double? Calculate(double num1, double num2)
        {
            return num1 * num2;
        }
    }
    public class DivideOperation: Operation
    {
        public override double? Calculate(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            return null;
        }
    }
    public class PowerOperation: Operation
    {
        public override double? Calculate(double num1, double num2)
        {
            return Math.Pow(num1, num2);
        }
    }
    public class ModuloOperation: Operation
    {
        public override double? Calculate(double num1, double num2)
        {
            return num1 % num2;
        }
    }
}