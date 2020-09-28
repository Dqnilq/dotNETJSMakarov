using System;

namespace CLCLTR
{
    public static class Calculator
    {
        public static int Calculator_Operations (int a, string oper, int b)
        {
            if (b == 0 && oper == "/")
            {
                throw new DivideByZeroException();
            }
            
            return oper switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a / b, 
                _ =>    throw new ArithmeticException()
            };

        }

        public static int GetNumber()
        {
            var x = int.Parse(Console.ReadLine());
            string str = x.ToString();
            char _char = Convert.ToChar(str);
            if (Char.IsDigit(_char) == false)
            {
                throw new NotSupportedException();
            }
            return x;
        }

        public static void GetNumber(string x)
        {
            throw  new ArgumentException();
        }

        public static void GetNumber(char y)
        {
            throw  new ArgumentException();
        }
        
    } 
    
    
    static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var a = Calculator.GetNumber();
                var oper = (Console.ReadLine());
                var b = Calculator.GetNumber();
                var res = Calculator.Calculator_Operations(a, oper, b);
                Console.WriteLine(res);
                Tests.TestOperation(); //Console Test's! 
            }
            catch    
            {
                throw new Exception("Error! Reload!");
            }
            finally
            {
                Console.WriteLine("Exit..");
            }
                       

        }
    }
}