using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q7
{
    class Program
    {
        public static bool CompareObjects(object name, object name2)
        {
            if (name.ToString().Length != name2.ToString().Length)
                return false;
            else
            {
                for (int i = 0;i<name.ToString().Length;i++)
                {
                    if (name.ToString()[i] != name2.ToString()[i]){
                        return false;

                    }
                }
            }
            return true;
            
        }
        static void Main(string[] args)
        {
            string string1 = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            string string2 = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            if (CompareObjects(string1, string2))
                Console.WriteLine("string1 = string2 ");
            else
                Console.WriteLine("string1 != string2 ");
            Console.WriteLine("Press Any Key to Exit...");
            Console.ReadKey();
        }
    }
}
