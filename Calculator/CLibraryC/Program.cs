using System;

namespace CLibraryC
{
    public class Program
    {
        public static double Res;
        public static void Main(string[] args)
        {
            Res = CalculatorC.Calculate("2+3-1");
            Console.WriteLine(Res);
        } 
    }
}