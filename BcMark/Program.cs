using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BcMark
{
    
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SimpleClass>();
        }
    }
}