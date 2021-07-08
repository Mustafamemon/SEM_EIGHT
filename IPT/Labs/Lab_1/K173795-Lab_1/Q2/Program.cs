using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the String : ");
            string input = Console.ReadLine();

            input =  input.Substring(0, 4).ToLower() + input.Substring(4, input.Length-4).ToUpper();
            Console.WriteLine("Tranform  : " +  input);
            Console.WriteLine("Press Any Key to Exit...");
            Console.ReadKey();
        }
    }
}
