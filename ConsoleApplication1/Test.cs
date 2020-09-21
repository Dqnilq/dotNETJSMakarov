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
            Assert.AreEqual(10,Calculator.Calculator_Operations(5, "+", 5));  //Unit Test!
            Console.WriteLine("+" + " " + Test(10, Calculator.Calculator_Operations(5, "+", 5)));  //Console Test! 
        }
        
        [Test]
        public static void Minus_5Munis5_0Returned()
        {
            Assert.AreEqual(0,Calculator.Calculator_Operations(5, "-", 5));  //Unit Test!
            Console.WriteLine( "-" + " " + Test(0,Calculator.Calculator_Operations(5, "-", 5)));  //Console Test!
        }
        
        [Test]
        public static void Multi_5Multi5_25Returned()
        {
            Assert.AreEqual(25,Calculator.Calculator_Operations(5, "*", 5));  //Unit Test!
            Console.WriteLine( "*" + " " + Test(25,Calculator.Calculator_Operations(5, "*", 5)));  //Console Test! 
        }
        
        [Test]
        public static void Div_5Div5_1Returned()
        {
            Assert.AreEqual(1, Calculator.Calculator_Operations(5, "/", 5));  //Unit Test!
            Console.WriteLine( "/" + " " + Test(1,Calculator.Calculator_Operations(5, "/", 5)));  //Console Test! 
        }


        [Test]
        public static void Div_Num_Zero_Exeption()
        {
            Assert.Throws<DivideByZeroException>(()=>Calculator.Calculator_Operations(5, "/", 0));
        }

        [Test]
        public static void Uncorrect_Oper_Exeption()
        {
            Assert.Throws<ArithmeticException>(()=> Calculator.Calculator_Operations(5, "awdawdwa", 10));
        }

        [Test]
        public static void Uncorrect_Input_Numbers_String()
        {
            Assert.Throws<ArgumentException>(()=> Calculator.GetNumber("dwad"));
        }
        
        [Test]
        public static void Uncorrect_Input_Numbers_Char()
        {
            Assert.Throws<ArgumentException>(()=> Calculator.GetNumber('c'));
        }


        internal static void TestOperation()  //Console Test's! 
        {
            try
            {
                Sum_5Plus5_10Returned();
                Minus_5Munis5_0Returned();
                Multi_5Multi5_25Returned();
                Div_5Div5_1Returned();
            }
            catch 
            {
                throw  new Exception("Error!");
            }
               
        }

    }
    
    
    
    
    
    
    

  
}