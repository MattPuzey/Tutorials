using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = AddNumbers(64, 32);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static int AddNumbers(int numberOne, int numberTwo)
        {
            int CalculationResult;
            CalculationResult = numberOne + numberTwo;
            return CalculationResult;
        }
    }
}
