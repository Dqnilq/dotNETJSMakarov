using System;

namespace ConsoleApplication1
{

    public class CalcTest 
    {

        private static bool Test(int x, int y)
        {
            if (x == y)
            {
                return true;
            }
            return false;
        }
        
        internal static void TestOperation()
        {
               Console.WriteLine( "+" + " " + Test(10,Calculator.NewMethod(5, "+", 5)));
               Console.WriteLine( "-" + " " + Test(0,Calculator.NewMethod(5, "-", 5)));
               Console.WriteLine( "*" + " " + Test(25,Calculator.NewMethod(5, "*", 5)));
               Console.WriteLine( "/" + " " + Test(1,Calculator.NewMethod(5, "/", 5)));
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
                        CalcTest.TestOperation();

        }
    }
}
