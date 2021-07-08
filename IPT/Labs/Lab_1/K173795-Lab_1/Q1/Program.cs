using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("List of Prime form 2 to " + number);
            for (int i = 2; i <= number; i++)
            {
                bool flag = false;
                for (int j = 2; j < i / 2 + 1; j++)
                {
                    if (i % j == 0)
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("Press Any Key to Exit...");
            Console.ReadKey();
        }
    }
}
