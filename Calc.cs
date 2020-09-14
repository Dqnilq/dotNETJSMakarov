using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
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
                => throw new NotSupportedException()
            };
        }

        public static int GetNumber()
        {
            return int.Parse(Console.ReadLine());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = Calculator.GetNumber();
            var oper = (Console.ReadLine());
            var b = Calculator.GetNumber();
            var res = Calculator.NewMethod(a, oper, b);
            Console.WriteLine(res);

          
        }


    }
}
