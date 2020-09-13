using System;

namespace ConsoleApplication1
{

    public class Calc_Operations_Test 
    {

        private static bool Test(int x, int y)
        {
            if (x == y)
            {
                return true;
            }
            return false;
        }

        private static void Sum_5Plus5_10Returned()
        {
            Console.WriteLine("+" + " " + Test(10, Calculator.NewMethod(5, "+", 5)));
        }
        private static void Minus_5Munis5_0Returned()
        {
            Console.WriteLine( "-" + " " + Test(0,Calculator.NewMethod(5, "-", 5)));
        }
        
        private static void Multi_5Multi5_25Returned()
        {
            Console.WriteLine( "*" + " " + Test(25,Calculator.NewMethod(5, "*", 5)));
        }
        private static void Div_5Div5_1Returned()
        {
            Console.WriteLine( "*" + " " + Test(25,Calculator.NewMethod(5, "*", 5)));
        }
        internal static void TestOperation()
        {
               Sum_5Plus5_10Returned();
               Minus_5Munis5_0Returned();
               Multi_5Multi5_25Returned();
               Div_5Div5_1Returned();
        }
        
    }
 public class Calculator
    {
        public static int NewMethod(int a, string oper, int b)
        {
            return oper switch
            {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => a / b, 
                
             _ =>    throw new NotSupportedException()
            };
        }

        public static int GetNumber()
        {
            return int.Parse(Console.ReadLine()!);
        }
    }
    internal static class Program
    {
    
        public static void Main(string[] args)
        {
                        var a = Calculator.GetNumber();
                        var oper = (Console.ReadLine());
                        var b = Calculator.GetNumber();
                        var res = Calculator.NewMethod(a, oper, b);
                        Console.WriteLine(res);
                        Calc_Operations_Test.TestOperation();

        }
    }
}
