using System;

namespace stuff.Exceptions
{
    public static class Input
    {
        public static int[] HandleInput()
        {
            var nums = new int[2];
            
            Console.Write("Enter first number: ");
            nums[0] = ParseNumberFromInput();
            
            Console.Write("Enter second number: ");
            nums[1] = ParseNumberFromInput();

            return nums;
        }

        private static int ParseNumberFromInput()
        {
            var inputNum = 0; 
            var success = false;
            while (!success)
            {
                var input = Console.ReadLine();
                try
                {
                    inputNum = int.Parse(input);
                    success = true;
                }
                catch
                {
                    Console.Write("Wrong input. Try again: ");
                }
            }
            return inputNum;
        }
        
        public static void Divide(int[] numbersToDivide)
        {
            if (numbersToDivide.Length > 2)
            {
                throw new Exception("More than 2 nums to divide");
            }

            try
            {
                var result = numbersToDivide[0] / numbersToDivide[1];
                Console.WriteLine(result);
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }
    }
}