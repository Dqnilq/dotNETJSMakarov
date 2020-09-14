using System;
using NUnit.Framework;

namespace ConsoleApplication1
{

    public static class Tests
    {
        private static bool Test(int x, int y)
        {
            return x == y;
        }

        [Test]
        public static void Sum_5Plus5_10Returned()
        {
            Assert.AreEqual(10,Calculator.NewMethod(5, "+", 5));  //Unit Test!
            Console.WriteLine("+" + " " + Test(10, Calculator.NewMethod(5, "+", 5)));  //Console Test! 
        }
        
        [Test]
        public static void Minus_5Munis5_0Returned()
        {
            Assert.AreEqual(0,Calculator.NewMethod(5, "-", 5));  //Unit Test!
            Console.WriteLine( "-" + " " + Test(0,Calculator.NewMethod(5, "-", 5)));  //Console Test!
        }
        
        [Test]
        public static void Multi_5Multi5_25Returned()
        {
            Assert.AreEqual(25,Calculator.NewMethod(5, "*", 5));  //Unit Test!
            Console.WriteLine( "*" + " " + Test(25,Calculator.NewMethod(5, "*", 5)));  //Console Test! 
        }
        
        [Test]
        public static void Div_5Div5_1Returned()
        {
            Assert.AreEqual(1, Calculator.NewMethod(5, "/", 5));  //Unit Test!
            Assert.AreEqual(0, Calculator.NewMethod(5, "/", 0));  //Unit Test!
            Console.WriteLine( "/" + " " + Test(1,Calculator.NewMethod(5, "/", 5)));  //Console Test! 
        }
        internal static void TestOperation()  //Console Test's! 
        {
               Sum_5Plus5_10Returned();
               Minus_5Munis5_0Returned();
               Multi_5Multi5_25Returned();
               Div_5Div5_1Returned();
        }
        
    }
  public static class Calculator
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
                        Tests.TestOperation();  //Console Test's! 

        }
    }
}
