using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q5
{
    class Program
    {
        class Account
        {
            public int Balance()
            {
                return 20;
            }
        }
        class Ammount : Account
        {
            public new int Balance()
            {
                return 10;
            }
        }
        static void Main(string[] args)
        {
            Ammount amt = new Ammount();
            Console.WriteLine("Balance : " + amt.Balance());
            Console.WriteLine("Press Any Key to Exit...");
            Console.ReadKey();
        }
    }
}
